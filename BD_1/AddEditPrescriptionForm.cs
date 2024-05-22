using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace BD_1
{
    public partial class AddEditPrescriptionForm : Form
    {
        private int? prescriptionId;

        public AddEditPrescriptionForm(int? id = null)
        {
            InitializeComponent();
            LoadComboBoxData();
            prescriptionId = id;
            comboBoxStatus.Enabled = false;

            if (prescriptionId.HasValue)
            {
                LoadPrescriptionData(prescriptionId.Value);
                comboBoxStatus.Enabled = true;
            }
        }

        private void LoadComboBoxData()
        {
            LoadPatients();
            LoadDoctors();
            LoadDiagnoses();
            LoadMedications();
            LoadInstructions();
            comboBoxStatus.Items.AddRange(new string[] { "pending", "in production", "ready", "collected" });
        }

        private void LoadPatients()
        {
            string query = "SELECT id, full_name FROM patients";
            LoadComboBox(comboBoxPatient, query, "full_name", "id");
        }

        private void LoadDoctors()
        {
            string query = "SELECT id, full_name FROM doctors";
            LoadComboBox(comboBoxDoctor, query, "full_name", "id");
        }

        private void LoadDiagnoses()
        {
            string query = "SELECT id, diagnosis_name FROM diagnoses";
            LoadComboBox(comboBoxDiagnosis, query, "diagnosis_name", "id");
        }

        private void LoadMedications()
        {
            string query = "SELECT mi.id, m.name " +
                           "FROM medication_ingredients mi " +
                           "JOIN medications m ON mi.medication_id = m.id";
            LoadComboBox(comboBoxMedicine, query, "name", "id");
        }

        private void LoadInstructions()
        {
            string query = "SELECT id, usage_instructions FROM instructions";
            LoadComboBox(comboBoxInstruction, query, "usage_instructions", "id");
        }

        private void LoadComboBox(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            MySqlCommand command = new MySqlCommand(query, SQLConnection.connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        private void LoadPrescriptionData(int id)
        {
            string query = "SELECT patient_id, doctor_id, diagnosis_id, medication_id, quantity, instruction_id, status FROM prescriptions WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, SQLConnection.connection);
            command.Parameters.AddWithValue("@id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    comboBoxPatient.SelectedValue = reader["patient_id"];
                    comboBoxDoctor.SelectedValue = reader["doctor_id"];
                    comboBoxDiagnosis.SelectedValue = reader["diagnosis_id"];
                    comboBoxMedicine.SelectedValue = reader["medication_id"];
                    numericUpDownValMedicine.Value = Convert.ToInt32(reader["quantity"]);
                    comboBoxInstruction.SelectedValue = reader["instruction_id"];
                    comboBoxStatus.SelectedValue = reader["status"];
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (prescriptionId.HasValue)
                {
                    UpdatePrescription(prescriptionId.Value);
                }
                else
                {
                    SavePrescription();
                }
            }
        }

        private bool ValidateForm()
        {
            if (comboBoxPatient.SelectedValue == null ||
                comboBoxDoctor.SelectedValue == null ||
                comboBoxDiagnosis.SelectedValue == null ||
                comboBoxMedicine.SelectedValue == null ||
                comboBoxInstruction.SelectedValue == null ||
                numericUpDownValMedicine.Value <= 0)
            {
                MessageBox.Show("Please fill in all fields and ensure medication quantity is greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SavePrescription()
        {
            string prescriptionQuery = "INSERT INTO prescriptions (patient_id, doctor_id, diagnosis_id, medication_id, quantity, instruction_id, status, order_time) " +
                                       "VALUES (@patient_id, @doctor_id, @diagnosis_id, @medication_id, @quantity, @instruction_id, 'pending', NOW())";

            using (MySqlCommand prescriptionCommand = new MySqlCommand(prescriptionQuery, SQLConnection.connection))
            {
                prescriptionCommand.Parameters.AddWithValue("@patient_id", comboBoxPatient.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@doctor_id", comboBoxDoctor.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@diagnosis_id", comboBoxDiagnosis.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@medication_id", comboBoxMedicine.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@instruction_id", comboBoxInstruction.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@quantity", numericUpDownValMedicine.Value);

                MySqlTransaction transaction = null;

                try
                {
                    transaction = SQLConnection.connection.BeginTransaction();
                    prescriptionCommand.Transaction = transaction;

                    prescriptionCommand.ExecuteNonQuery();
                    long prescriptionId = prescriptionCommand.LastInsertedId;

                    SaveOrder(prescriptionId, transaction);

                    transaction.Commit();

                    MessageBox.Show("Prescription and order saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error saving prescription and order: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdatePrescription(int id)
        {
            string prescriptionQuery = @"UPDATE prescriptions 
                                        SET patient_id = @patient_id,
                                        doctor_id = @doctor_id,
                                        diagnosis_id = @diagnosis_id,
                                        medication_id = @medication_id,
                                        quantity = @quantity,
                                        instruction_id = @instruction_id,
                                        status = @status
                                        WHERE id = @id";

            using (MySqlCommand prescriptionCommand = new MySqlCommand(prescriptionQuery, SQLConnection.connection))
            {
                prescriptionCommand.Parameters.AddWithValue("@patient_id", comboBoxPatient.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@doctor_id", comboBoxDoctor.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@diagnosis_id", comboBoxDiagnosis.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@medication_id", comboBoxMedicine.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@instruction_id", comboBoxInstruction.SelectedValue);
                prescriptionCommand.Parameters.AddWithValue("@quantity", numericUpDownValMedicine.Value);
                prescriptionCommand.Parameters.AddWithValue("@status", comboBoxStatus.SelectedItem);
                prescriptionCommand.Parameters.AddWithValue("@id", id);

                MySqlTransaction transaction = null;

                try
                {
                    transaction = SQLConnection.connection.BeginTransaction();
                    prescriptionCommand.Transaction = transaction;

                    prescriptionCommand.ExecuteNonQuery();

                    // Логика для обновления заказа, связанного с рецептом
                    string updateOrderQuery = "UPDATE orders SET patient_id = @patient_id WHERE prescription_id = @prescription_id";

                    using (MySqlCommand orderCommand = new MySqlCommand(updateOrderQuery, SQLConnection.connection))
                    {
                        orderCommand.Transaction = transaction;
                        orderCommand.Parameters.AddWithValue("@patient_id", comboBoxPatient.SelectedValue);
                        orderCommand.Parameters.AddWithValue("@prescription_id", id);

                        orderCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Prescription updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error updating prescription: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveOrder(long prescriptionId, MySqlTransaction transaction)
        {
            string orderQuery = "INSERT INTO orders (patient_id, prescription_id, status, ordered_at) " +
                                "VALUES (@patient_id, @prescription_id, 'pending', NOW())";

            using (MySqlCommand orderCommand = new MySqlCommand(orderQuery, SQLConnection.connection))
            {
                orderCommand.Transaction = transaction;
                orderCommand.Parameters.AddWithValue("@patient_id", comboBoxPatient.SelectedValue);
                orderCommand.Parameters.AddWithValue("@prescription_id", prescriptionId);

                orderCommand.ExecuteNonQuery();
                long orderId = orderCommand.LastInsertedId;

                // Логика для проверки ингредиентов и обновления статуса заказа
                string checkIngredientsQuery = @"
                    SELECT COUNT(*)
                    FROM medication_ingredients mi
                    JOIN ingredients i ON mi.ingredient_id = i.id
                    WHERE mi.medication_id = @medication_id
                      AND i.stock < mi.quantity";

                using (MySqlCommand checkCommand = new MySqlCommand(checkIngredientsQuery, SQLConnection.connection))
                {
                    checkCommand.Transaction = transaction;
                    checkCommand.Parameters.AddWithValue("@medication_id", comboBoxMedicine.SelectedValue);

                    int missingIngredients = Convert.ToInt32(checkCommand.ExecuteScalar());

                    string updateOrderQuery;

                    if (missingIngredients > 0)
                    {
                        updateOrderQuery = "UPDATE orders SET status = 'pending' WHERE id = @order_id";
                    }
                    else
                    {
                        updateOrderQuery = "UPDATE orders SET status = 'in production' WHERE id = @order_id";

                        // Резервируем компоненты
                        string reserveIngredientsQuery = @"
                            UPDATE ingredients i
                            JOIN medication_ingredients mi ON i.id = mi.ingredient_id
                            SET i.stock = i.stock - mi.quantity
                            WHERE mi.medication_id = @medication_id";

                        using (MySqlCommand reserveCommand = new MySqlCommand(reserveIngredientsQuery, SQLConnection.connection))
                        {
                            reserveCommand.Transaction = transaction;
                            reserveCommand.Parameters.AddWithValue("@medication_id", comboBoxMedicine.SelectedValue);
                            reserveCommand.ExecuteNonQuery();
                        }
                    }

                    using (MySqlCommand updateOrderCommand = new MySqlCommand(updateOrderQuery, SQLConnection.connection))
                    {
                        updateOrderCommand.Transaction = transaction;
                        updateOrderCommand.Parameters.AddWithValue("@order_id", orderId);
                        updateOrderCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BD_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Visible = false;
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (!SQLConnection.connection.Ping())
                this.Close();
            this.Visible = true;
            comboBoxEntities.Items.AddRange(new string[] { "��������", "�����", "�������", "���������", "��������", "����������", "�����", "�����������" });
            comboBoxEntities.SelectedIndex = 0;

            // ��������� ������ �� ���������
            LoadPatients();
        }

        // ����� ��� �������� ������ � DataGridView
        private void LoadData(string query)
        {
            MySqlCommand command = new MySqlCommand(query, SQLConnection.connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // ������ ��� �������� ������ ��������� ���������
        private void LoadPatients()
        {
            string query = "SELECT patients.id, patients.full_name, patients.phone, patients.address FROM patients";
            LoadData(query);
        }

        private void LoadDoctors()
        {
            string query = "SELECT doctors.id, doctors.full_name, doctors.signature, doctors.seal FROM doctors";
            LoadData(query);
        }

        private void LoadPrescriptions()
        {
            string query = @"
                SELECT p.id, 
                pt.full_name AS patient_name, 
                doc.full_name AS doctor_name, 
                d.diagnosis_name, 
                m.name AS medication_name, 
                mi.quantity, 
                i.usage_instructions, 
                p.status, 
                p.order_time, 
                p.due_time, 
                p.collection_time 
                FROM prescriptions p
                JOIN patients pt ON p.patient_id = pt.id
                JOIN doctors doc ON p.doctor_id = doc.id
                JOIN diagnoses d ON p.diagnosis_id = d.id
                JOIN medication_ingredients mi ON p.medication_id = mi.id
                JOIN medications m ON mi.medication_id = m.id
                JOIN instructions i ON p.instruction_id = i.id";
            LoadData(query);
        }

        private void LoadMedicines()
        {
            string query = "SELECT medications.id, medications.name, medications.type, " +
                           "preparation_methods.method_name AS preparation_method, " +
                           "medications.price " +
                           "FROM medications " +
                           "JOIN preparation_methods ON medications.preparation_method_id = preparation_methods.id";
            LoadData(query);
        }

        private void LoadDiagnoses()
        {
            string query = "SELECT id, diagnosis_name FROM diagnoses";
            LoadData(query);
        }

        private void LoadTechniques()
        {
            string query = "SELECT id, method_name, method_description FROM preparation_methods";
            LoadData(query);
        }

        private void LoadStock()
        {
            string query = "SELECT id, name, stock, critical_level, price FROM ingredients";
            LoadData(query);
        }

        private void LoadMedications()
        {
            string query = @"
                SELECT mi.id, m.name AS medication_name, i.name AS ingredient_name, mi.quantity, mi.critical_level
                FROM medication_ingredients mi
                JOIN medications m ON mi.medication_id = m.id
                JOIN ingredients i ON mi.ingredient_id = i.id";
            LoadData(query);
        }

        // ���������� ������� ������ �������� � �����-�����
        private void ComboBoxEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEntity = comboBoxEntities.SelectedItem.ToString();

            switch (selectedEntity)
            {
                case "��������":
                    LoadPatients();
                    break;
                case "�����":
                    LoadDoctors();
                    break;
                case "�������":
                    LoadPrescriptions();
                    break;
                case "���������":
                    LoadMedicines();
                    break;
                case "��������":
                    LoadDiagnoses();
                    break;
                case "����������":
                    LoadTechniques();
                    break;
                case "�����":
                    LoadStock();
                    break;
                case "�����������":
                    LoadMedications();
                    break;
                default:
                    break;
            }
        }

        // ���������� ������� ������� ������ "��������"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string selectedEntity = comboBoxEntities.SelectedItem.ToString();

            // � ����������� �� ��������� �������� ��������� ��������������� ����� ��� ����������
            switch (selectedEntity)
            {
                case "��������":
                    AddEditPatientForm addPatientForm = new AddEditPatientForm();
                    addPatientForm.ShowDialog();
                    break;
                case "�����":
                    AddEditDoctorForm addDoctorForm = new AddEditDoctorForm();
                    addDoctorForm.ShowDialog();
                    break;
                case "�������":
                    AddEditPrescriptionForm addPrescriptionForm = new AddEditPrescriptionForm();
                    addPrescriptionForm.ShowDialog();
                    break;
                case "���������":
                    AddEditMedicationForm addMedicationForm = new AddEditMedicationForm();
                    addMedicationForm.ShowDialog();
                    break;
                case "��������":
                    AddEditDiagnosisForm addDiagnosisForm = new AddEditDiagnosisForm();
                    addDiagnosisForm.ShowDialog();
                    break;
                case "����������":
                    AddEditTechniqueForm addTechniqueForm = new AddEditTechniqueForm();
                    addTechniqueForm.ShowDialog();
                    break;
                case "�����������":
                    ReservationForm reservationForm = new ReservationForm();
                    reservationForm.ShowDialog();
                    break;
                default:
                    break;
            }

            // ����� �������� ����� ��������� ������������ ������
            ComboBoxEntities_SelectedIndexChanged(null, null);
        }

        // ���������� ������� ������� ������ "�������������"
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string selectedEntity = comboBoxEntities.SelectedItem.ToString();

            // � ����������� �� ��������� �������� ��������� ��������������� ����� ��� ��������������
            switch (selectedEntity)
            {
                case "��������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditPatientForm editPatientForm = new AddEditPatientForm(patientId);
                        editPatientForm.ShowDialog();
                    }
                    break;
                case "�����":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int doctorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditDoctorForm editDoctorForm = new AddEditDoctorForm(doctorId);
                        editDoctorForm.ShowDialog();
                    }
                    break;
                case "�������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int prescriptionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditPrescriptionForm editPrescriptionForm = new AddEditPrescriptionForm(prescriptionId);
                        editPrescriptionForm.ShowDialog();
                    }
                    break;
                case "���������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int medicationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditMedicationForm editMedicationForm = new AddEditMedicationForm(medicationId);
                        editMedicationForm.ShowDialog();
                    }
                    break;
                case "��������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int diagnosisId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditDiagnosisForm editDiagnosisForm = new AddEditDiagnosisForm(diagnosisId);
                        editDiagnosisForm.ShowDialog();
                    }
                    break;
                case "����������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int techniqueId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditTechniqueForm editTechniqueForm = new AddEditTechniqueForm(techniqueId);
                        editTechniqueForm.ShowDialog();
                    }
                    break;
                case "�����������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int reservationiId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        ReservationForm reservationForm = new ReservationForm(reservationiId);
                        reservationForm.ShowDialog();
                    }
                    break;
                default:
                    break;
            }

            // ����� �������� ����� ��������� ������������ ������
            ComboBoxEntities_SelectedIndexChanged(null, null);
        }

        // ���������� ������� ������� ������ "�������"
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string selectedEntity = comboBoxEntities.SelectedItem.ToString();

            // � ����������� �� ��������� �������� ������� ��������������� ������
            switch (selectedEntity)
            {
                case "��������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("patients", patientId);
                    }
                    break;
                case "�����":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int doctorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("doctors", doctorId);
                    }
                    break;
                case "�������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int prescriptionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        string deleteOrdersQuery = $"DELETE FROM orders WHERE prescription_id = {prescriptionId}";
                        MySqlCommand deleteOrdersCommand = new MySqlCommand(deleteOrdersQuery, SQLConnection.connection);
                        deleteOrdersCommand.ExecuteNonQuery();
                        DeleteEntity("prescriptions", prescriptionId);
                    }
                    break;
                case "���������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int medicationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("medications", medicationId);
                    }
                    break;
                case "��������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int diagnosisId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("diagnoses", diagnosisId);
                    }
                    break;
                case "����������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int techniqueId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("preparation_methods", techniqueId);
                    }
                    break;
                case "�����������":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int reservationiId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("medication_ingredients", reservationiId);
                    }
                    break;
                default:
                    break;
            }

            // ����� �������� ��������� ������������ ������
            ComboBoxEntities_SelectedIndexChanged(null, null);
        }

        // ����� ��� �������� ������ �� �������
        private void DeleteEntity(string tableName, int entityId)
        {
            string query = $"DELETE FROM {tableName} WHERE id = {entityId}";
            MySqlCommand command = new MySqlCommand(query, SQLConnection.connection);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("������ ������� �������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������ ��� �������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            ManageOrdersForm form = new ManageOrdersForm();
            form.ShowDialog();
        }

        private void buttonRepos_Click(object sender, EventArgs e)
        {
            ReportsForm form = new ReportsForm();
            form.ShowDialog();
        }
    }
}




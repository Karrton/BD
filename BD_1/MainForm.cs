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
            comboBoxEntities.Items.AddRange(new string[] { "Пациенты", "Врачи", "Рецепты", "Лекарства", "Диагнозы", "Технологии", "Склад", "Медикаменты" });
            comboBoxEntities.SelectedIndex = 0;

            // Загружаем данные по умолчанию
            LoadPatients();
        }

        // Метод для загрузки данных в DataGridView
        private void LoadData(string query)
        {
            MySqlCommand command = new MySqlCommand(query, SQLConnection.connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // Методы для загрузки данных различных сущностей
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

        // Обработчик события выбора элемента в комбо-боксе
        private void ComboBoxEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEntity = comboBoxEntities.SelectedItem.ToString();

            switch (selectedEntity)
            {
                case "Пациенты":
                    LoadPatients();
                    break;
                case "Врачи":
                    LoadDoctors();
                    break;
                case "Рецепты":
                    LoadPrescriptions();
                    break;
                case "Лекарства":
                    LoadMedicines();
                    break;
                case "Диагнозы":
                    LoadDiagnoses();
                    break;
                case "Технологии":
                    LoadTechniques();
                    break;
                case "Склад":
                    LoadStock();
                    break;
                case "Медикаменты":
                    LoadMedications();
                    break;
                default:
                    break;
            }
        }

        // Обработчик события нажатия кнопки "Добавить"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string selectedEntity = comboBoxEntities.SelectedItem.ToString();

            // В зависимости от выбранной сущности открываем соответствующую форму для добавления
            switch (selectedEntity)
            {
                case "Пациенты":
                    AddEditPatientForm addPatientForm = new AddEditPatientForm();
                    addPatientForm.ShowDialog();
                    break;
                case "Врачи":
                    AddEditDoctorForm addDoctorForm = new AddEditDoctorForm();
                    addDoctorForm.ShowDialog();
                    break;
                case "Рецепты":
                    AddEditPrescriptionForm addPrescriptionForm = new AddEditPrescriptionForm();
                    addPrescriptionForm.ShowDialog();
                    break;
                case "Лекарства":
                    AddEditMedicationForm addMedicationForm = new AddEditMedicationForm();
                    addMedicationForm.ShowDialog();
                    break;
                case "Диагнозы":
                    AddEditDiagnosisForm addDiagnosisForm = new AddEditDiagnosisForm();
                    addDiagnosisForm.ShowDialog();
                    break;
                case "Технологии":
                    AddEditTechniqueForm addTechniqueForm = new AddEditTechniqueForm();
                    addTechniqueForm.ShowDialog();
                    break;
                case "Медикаменты":
                    ReservationForm reservationForm = new ReservationForm();
                    reservationForm.ShowDialog();
                    break;
                default:
                    break;
            }

            // После закрытия формы обновляем отображаемые данные
            ComboBoxEntities_SelectedIndexChanged(null, null);
        }

        // Обработчик события нажатия кнопки "Редактировать"
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string selectedEntity = comboBoxEntities.SelectedItem.ToString();

            // В зависимости от выбранной сущности открываем соответствующую форму для редактирования
            switch (selectedEntity)
            {
                case "Пациенты":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditPatientForm editPatientForm = new AddEditPatientForm(patientId);
                        editPatientForm.ShowDialog();
                    }
                    break;
                case "Врачи":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int doctorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditDoctorForm editDoctorForm = new AddEditDoctorForm(doctorId);
                        editDoctorForm.ShowDialog();
                    }
                    break;
                case "Рецепты":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int prescriptionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditPrescriptionForm editPrescriptionForm = new AddEditPrescriptionForm(prescriptionId);
                        editPrescriptionForm.ShowDialog();
                    }
                    break;
                case "Лекарства":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int medicationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditMedicationForm editMedicationForm = new AddEditMedicationForm(medicationId);
                        editMedicationForm.ShowDialog();
                    }
                    break;
                case "Диагнозы":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int diagnosisId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditDiagnosisForm editDiagnosisForm = new AddEditDiagnosisForm(diagnosisId);
                        editDiagnosisForm.ShowDialog();
                    }
                    break;
                case "Технологии":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int techniqueId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        AddEditTechniqueForm editTechniqueForm = new AddEditTechniqueForm(techniqueId);
                        editTechniqueForm.ShowDialog();
                    }
                    break;
                case "Медикаменты":
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

            // После закрытия формы обновляем отображаемые данные
            ComboBoxEntities_SelectedIndexChanged(null, null);
        }

        // Обработчик события нажатия кнопки "Удалить"
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string selectedEntity = comboBoxEntities.SelectedItem.ToString();

            // В зависимости от выбранной сущности удаляем соответствующую запись
            switch (selectedEntity)
            {
                case "Пациенты":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("patients", patientId);
                    }
                    break;
                case "Врачи":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int doctorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("doctors", doctorId);
                    }
                    break;
                case "Рецепты":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int prescriptionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        string deleteOrdersQuery = $"DELETE FROM orders WHERE prescription_id = {prescriptionId}";
                        MySqlCommand deleteOrdersCommand = new MySqlCommand(deleteOrdersQuery, SQLConnection.connection);
                        deleteOrdersCommand.ExecuteNonQuery();
                        DeleteEntity("prescriptions", prescriptionId);
                    }
                    break;
                case "Лекарства":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int medicationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("medications", medicationId);
                    }
                    break;
                case "Диагнозы":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int diagnosisId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("diagnoses", diagnosisId);
                    }
                    break;
                case "Технологии":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int techniqueId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("preparation_methods", techniqueId);
                    }
                    break;
                case "Медикаменты":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int reservationiId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                        DeleteEntity("medication_ingredients", reservationiId);
                    }
                    break;
                default:
                    break;
            }

            // После удаления обновляем отображаемые данные
            ComboBoxEntities_SelectedIndexChanged(null, null);
        }

        // Метод для удаления записи из таблицы
        private void DeleteEntity(string tableName, int entityId)
        {
            string query = $"DELETE FROM {tableName} WHERE id = {entityId}";
            MySqlCommand command = new MySqlCommand(query, SQLConnection.connection);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении записи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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




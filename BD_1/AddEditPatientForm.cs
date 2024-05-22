using MySql.Data.MySqlClient;

namespace BD_1
{
    public partial class AddEditPatientForm : Form
    {
        private int patientId; // Поле для хранения идентификатора редактируемого пациента
        private bool isEditing; // Поле для отслеживания режима редактирования

        public AddEditPatientForm()
        {
            InitializeComponent();
            isEditing = false;
        }

        // Конструктор для редактирования записи
        public AddEditPatientForm(int id) : this()
        {
            patientId = id;
            isEditing = true;
            LoadPatientData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (isEditing)
                {
                    UpdatePatient();
                }
                else
                {
                    SavePatient();
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm()
        {
            // Валидация формы, например, проверка на заполненность всех полей
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text) ||
                string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SavePatient()
        {
            string query = "INSERT INTO patients (full_name, phone, address) " +
                           "VALUES (@full_name, @phone, @address)";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@full_name", textBoxName.Text);
                command.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                command.Parameters.AddWithValue("@address", textBoxAddress.Text);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Patient information saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving patient information: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdatePatient()
        {
            string query = "UPDATE patients SET full_name = @full_name, phone = @phone, address = @address WHERE id = @patient_id";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@full_name", textBoxName.Text);
                command.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                command.Parameters.AddWithValue("@address", textBoxAddress.Text);
                command.Parameters.AddWithValue("@patient_id", patientId);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Patient information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating patient information: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Загрузка данных о редактируемом пациенте
        private void LoadPatientData()
        {
            string query = "SELECT full_name, phone, address FROM patients WHERE id = @patient_id";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@patient_id", patientId);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxName.Text = reader["full_name"].ToString();
                            textBoxPhone.Text = reader["phone"].ToString();
                            textBoxAddress.Text = reader["address"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading patient data: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
    }
}

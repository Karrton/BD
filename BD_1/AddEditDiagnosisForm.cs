using MySql.Data.MySqlClient;

namespace BD_1
{
    public partial class AddEditDiagnosisForm : Form
    {
        private int diagnosisId; // Поле для хранения идентификатора редактируемой записи
        private bool isEditing; // Поле для отслеживания режима редактирования

        public AddEditDiagnosisForm()
        {
            InitializeComponent();
            isEditing = false;
        }

        // Конструктор для редактирования записи
        public AddEditDiagnosisForm(int id) : this()
        {
            diagnosisId = id;
            isEditing = true;
            LoadDiagnosisData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (isEditing)
                {
                    UpdateDiagnosis();
                }
                else
                {
                    SaveDiagnosis();
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите название диагноза.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SaveDiagnosis()
        {
            string query = "INSERT INTO diagnoses (diagnosis_name) VALUES (@diagnosis_name)";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@diagnosis_name", textBoxName.Text);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Диагноз сохранён!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateDiagnosis()
        {
            string query = "UPDATE diagnoses SET diagnosis_name = @diagnosis_name WHERE id = @diagnosis_id";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@diagnosis_name", textBoxName.Text);
                command.Parameters.AddWithValue("@diagnosis_id", diagnosisId);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Diagnosis updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating diagnosis: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Загрузка данных о редактируемой записи
        private void LoadDiagnosisData()
        {
            string query = "SELECT diagnosis_name FROM diagnoses WHERE id = @diagnosis_id";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@diagnosis_id", diagnosisId);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxName.Text = reader["diagnosis_name"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading diagnosis data: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
    }
}
using MySql.Data.MySqlClient;

namespace BD_1
{
    public partial class AddEditDoctorForm : Form
    {
        private int doctorId; // Поле для хранения идентификатора редактируемой записи
        private bool isEditing; // Поле для отслеживания режима редактирования

        public AddEditDoctorForm()
        {
            InitializeComponent();
            isEditing = false;
        }

        // Конструктор для редактирования записи
        public AddEditDoctorForm(int id) : this()
        {
            doctorId = id;
            isEditing = true;
            LoadDoctorData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (isEditing)
                {
                    UpdateDoctor();
                }
                else
                {
                    SaveDoctor();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please enter a doctor name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SaveDoctor()
        {
            string query = "INSERT INTO doctors (full_name, signature, seal) VALUES (@full_name, @signature, @seal)";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@full_name", textBoxName.Text);
                command.Parameters.AddWithValue("@signature", textBoxSignature.Text);
                command.Parameters.AddWithValue("@seal", textBoxSeal.Text);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Doctor saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving doctor: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateDoctor()
        {
            string query = "UPDATE doctors SET full_name = @full_name, signature = @signature, seal = @seal WHERE id = @doctor_id";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@full_name", textBoxName.Text);
                command.Parameters.AddWithValue("@signature", textBoxSignature.Text);
                command.Parameters.AddWithValue("@seal", textBoxSeal.Text);
                command.Parameters.AddWithValue("@doctor_id", doctorId);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Doctor updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating doctor: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Загрузка данных о редактируемой записи
        private void LoadDoctorData()
        {
            string query = "SELECT full_name, signature, seal FROM doctors WHERE id = @doctor_id";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@doctor_id", doctorId);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxName.Text = reader["full_name"].ToString();
                            textBoxSignature.Text = reader["signature"].ToString();
                            textBoxSeal.Text = reader["seal"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading doctor data: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
    }
}
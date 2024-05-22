using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BD_1
{
    public partial class AddEditTechniqueForm : Form
    {
        private int techniqueId = -1; // Идентификатор метода приготовления, -1 означает режим добавления нового метода

        public AddEditTechniqueForm()
        {
            InitializeComponent();
        }

        public AddEditTechniqueForm(int techniqueId) : this()
        {
            this.techniqueId = techniqueId;

            if (techniqueId != -1)
            {
                LoadTechniqueData();
            }
        }

        private void LoadTechniqueData()
        {
            try
            {
                string query = "SELECT method_name, method_description FROM preparation_methods WHERE id = @techniqueId";

                using (MySqlCommand cmd = new MySqlCommand(query, SQLConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@techniqueId", techniqueId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxTechniqueName.Text = reader["method_name"].ToString();
                            textBoxTechniqueDescription.Text = reader["method_description"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Метод приготовления с указанным идентификатором не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке данных метода приготовления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void buttonSaveTechnique_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTechniqueName.Text) || string.IsNullOrWhiteSpace(textBoxTechniqueDescription.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (techniqueId == -1)
                {
                    MySqlCommand insertCmd = new MySqlCommand("INSERT INTO preparation_methods (method_name, method_description) VALUES (@methodName, @methodDescription)", SQLConnection.connection);

                    insertCmd.Parameters.AddWithValue("@methodName", textBoxTechniqueName.Text);
                    insertCmd.Parameters.AddWithValue("@methodDescription", textBoxTechniqueDescription.Text);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Метод приготовления успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MySqlCommand updateCmd = new MySqlCommand("UPDATE preparation_methods SET method_name = @methodName, method_description = @methodDescription WHERE id = @techniqueId", SQLConnection.connection);

                    updateCmd.Parameters.AddWithValue("@methodName", textBoxTechniqueName.Text);
                    updateCmd.Parameters.AddWithValue("@methodDescription", textBoxTechniqueDescription.Text);
                    updateCmd.Parameters.AddWithValue("@techniqueId", techniqueId);

                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Метод приготовления успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении метода приготовления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
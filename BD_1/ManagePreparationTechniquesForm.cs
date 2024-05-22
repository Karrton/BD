using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BD_1
{
    public partial class ManagePreparationTechniquesForm : Form
    {
        public ManagePreparationTechniquesForm()
        {
            InitializeComponent();
            LoadTechniques();
        }

        private void LoadTechniques()
        {
            string query = "SELECT * FROM preparation_methods";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, SQLConnection.connection))
            {
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridViewTechniques.DataSource = dataSet.Tables[0];
            }
            dataGridViewTechniques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ButtonAddTechnique_Click(object sender, EventArgs e)
        {
            AddEditTechniqueForm addTechniqueForm = new AddEditTechniqueForm();
            addTechniqueForm.ShowDialog();
            LoadTechniques();
        }

        private void ButtonUpdateTechnique_Click(object sender, EventArgs e)
        {
            if (dataGridViewTechniques.SelectedRows.Count > 0)
            {
                int techniqueId = Convert.ToInt32(dataGridViewTechniques.SelectedRows[0].Cells["id"].Value);
                AddEditTechniqueForm editTechniqueForm = new AddEditTechniqueForm(techniqueId);
                editTechniqueForm.ShowDialog();
                LoadTechniques();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите метод приготовления для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDeleteTechnique_Click(object sender, EventArgs e)
        {
            if (dataGridViewTechniques.SelectedRows.Count > 0)
            {
                int techniqueId = Convert.ToInt32(dataGridViewTechniques.SelectedRows[0].Cells["id"].Value);
                string query = "DELETE FROM preparation_methods WHERE id = @techniqueId";
                using (MySqlCommand cmd = new MySqlCommand(query, SQLConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@techniqueId", techniqueId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Метод приготовления успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTechniques();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка при удалении метода приготовления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите метод приготовления для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
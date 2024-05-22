using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BD_1
{
    public partial class AddEditMedicationForm : Form
    {
        private int? medicationId = null; // Для хранения ID редактируемого медикамента

        public AddEditMedicationForm(int? id = null)
        {
            InitializeComponent();
            LoadPreparationMethods();
            LoadMedicationTypes();

            if (id.HasValue)
            {
                medicationId = id;
                LoadMedicationDetails(id.Value);
            }
        }

        private void LoadPreparationMethods()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id, method_name FROM preparation_methods", SQLConnection.connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxPreparationMethod.DisplayMember = "method_name";
                comboBoxPreparationMethod.ValueMember = "id";
                comboBoxPreparationMethod.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке методов приготовления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMedicationTypes()
        {
            comboBoxType.Items.AddRange(new object[]
            {
                "готовые",
                "микстура",
                "мазь",
                "раствор",
                "порошок"
            });
        }

        private void LoadMedicationDetails(int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT name, type, preparation_method_id, price FROM medications WHERE id = @id", SQLConnection.connection);
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBoxName.Text = reader["name"].ToString();
                    comboBoxType.SelectedItem = reader["type"].ToString();
                    comboBoxPreparationMethod.SelectedValue = reader["preparation_method_id"];
                    numericUpDownPrice.Value = Convert.ToDecimal(reader["price"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных лекарства: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Проверяем, что поля не пустые
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || comboBoxType.SelectedIndex == -1 || comboBoxPreparationMethod.SelectedIndex == -1 || numericUpDownPrice.Value <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MySqlCommand cmd;
                if (medicationId.HasValue)
                {
                    // Обновление существующего медикамента
                    cmd = new MySqlCommand("UPDATE medications SET name = @name, type = @type, preparation_method_id = @preparationMethodId, price = @price WHERE id = @id", SQLConnection.connection);
                    cmd.Parameters.AddWithValue("@id", medicationId.Value);
                }
                else
                {
                    // Вставка нового медикамента
                    cmd = new MySqlCommand("INSERT INTO medications (name, type, preparation_method_id, price) VALUES (@name, @type, @preparationMethodId, @price)", SQLConnection.connection);
                }

                // Добавляем параметры
                cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                cmd.Parameters.AddWithValue("@type", comboBoxType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@preparationMethodId", (int)comboBoxPreparationMethod.SelectedValue);
                cmd.Parameters.AddWithValue("@price", numericUpDownPrice.Value);

                // Выполняем запрос
                cmd.ExecuteNonQuery();

                MessageBox.Show("Лекарство успешно сохранено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении лекарства: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void buttonClancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
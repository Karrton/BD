using MySql.Data.MySqlClient;
using System.Data;

namespace BD_1
{
    public partial class ReservationForm : Form
    {
        private int? reservationId;

        public ReservationForm(int? id = null)
        {
            InitializeComponent();
            reservationId = id;

            if (reservationId.HasValue)
            {
                LoadReservationData(reservationId.Value);
                btnSubmit.Text = "Обновить";
            }
            else
            {
                btnSubmit.Text = "Сохранить";
            }

            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            LoadMedicationIDs();
            LoadIngredientIDs();
        }

        private void LoadMedicationIDs()
        {
            string query = "SELECT id, name FROM medications";
            LoadComboBox(cmbMedicationID, query, "name", "id");
        }

        private void LoadIngredientIDs()
        {
            string query = "SELECT id, name FROM ingredients";
            LoadComboBox(cmbIngredientID, query, "name", "id");
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

        private void LoadReservationData(int id)
        {
            string query = "SELECT mi.medication_id, mi.ingredient_id, mi.quantity, i.critical_level " +
                           "FROM medication_ingredients mi " +
                           "INNER JOIN ingredients i ON mi.ingredient_id = i.id " +
                           "WHERE mi.id = @id";
            MySqlCommand command = new MySqlCommand(query, SQLConnection.connection);
            command.Parameters.AddWithValue("@id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    cmbMedicationID.SelectedValue = reader["medication_id"];
                    cmbIngredientID.SelectedValue = reader["ingredient_id"];
                    txtQuantity.Text = reader["quantity"].ToString();
                    textBoxCriticaLevel.Text = reader["critical_level"].ToString();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int medicationId = (int)cmbMedicationID.SelectedValue;
            int ingredientId = (int)cmbIngredientID.SelectedValue;
            int quantity;
            int criticalLevel;

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid number for Quantity.");
                return;
            }

            if (!int.TryParse(textBoxCriticaLevel.Text, out criticalLevel))
            {
                MessageBox.Show("Please enter a valid number for Critical Level.");
                return;
            }

            try
            {
                if (reservationId.HasValue)
                {
                    UpdateReservation(reservationId.Value, medicationId, ingredientId, quantity, criticalLevel);
                }
                else
                {
                    InsertReservation(medicationId, ingredientId, quantity, criticalLevel);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonClancel_Click(object sender, EventArgs e) 
        { 
            this.Close();
        }

        private void InsertReservation(int medicationId, int ingredientId, int quantity, int criticalLevel)
        {
            string query = "INSERT INTO medication_ingredients (medication_id, ingredient_id, quantity, critical_level) " +
                           "VALUES (@medicationId, @ingredientId, @quantity, @criticalLevel)";
            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@medicationId", medicationId);
                command.Parameters.AddWithValue("@ingredientId", ingredientId);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@criticalLevel", criticalLevel);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data inserted successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to insert data.");
                }
            }
        }

        private void UpdateReservation(int id, int medicationId, int ingredientId, int quantity, int criticalLevel)
        {
            string query = "UPDATE medication_ingredients SET medication_id = @medicationId, " +
                           "ingredient_id = @ingredientId, quantity = @quantity, critical_level = @criticalLevel " +
                           "WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@medicationId", medicationId);
                command.Parameters.AddWithValue("@ingredientId", ingredientId);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@criticalLevel", criticalLevel);
                command.Parameters.AddWithValue("@id", id);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update data.");
                }
            }
        }
    }
}

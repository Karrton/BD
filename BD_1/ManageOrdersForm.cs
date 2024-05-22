using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_1
{
    public partial class ManageOrdersForm : Form
    {
        public ManageOrdersForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            string query = "SELECT orders.id, patients.full_name AS patient_name, orders.prescription_id, orders.status, orders.ordered_at, orders.completed_at " +
                           "FROM orders " +
                           "JOIN patients ON orders.patient_id = patients.id";
            MySqlCommand command = new MySqlCommand(query, SQLConnection.connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridViewOrders.DataSource = dataTable;

            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ButtonUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                int orderId = (int)dataGridViewOrders.SelectedRows[0].Cells["id"].Value;
                string currentStatus = dataGridViewOrders.SelectedRows[0].Cells["status"].Value.ToString();
                string newStatus = PromptForNewStatus(currentStatus);

                if (!string.IsNullOrEmpty(newStatus))
                {
                    UpdateOrderStatus(orderId, newStatus);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ, чтобы обновить его статус.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PromptForNewStatus(string currentStatus)
        {
            string newStatus = currentStatus;
            using (var form = new Form())
            {
                form.Text = "Обновить статус заказа";
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Size = new Size(300, 150);

                Label label = new Label();
                label.Text = "Новый статус:";
                label.AutoSize = true;
                label.Location = new Point(20, 20);

                ComboBox comboBoxStatus = new ComboBox();
                comboBoxStatus.Location = new Point(120, 20);
                comboBoxStatus.Size = new Size(150, 20);
                comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxStatus.Items.AddRange(new string[] { "pending", "in production", "completed" });
                comboBoxStatus.SelectedItem = currentStatus;

                Button buttonOk = new Button();
                buttonOk.Text = "OK";
                buttonOk.DialogResult = DialogResult.OK;
                buttonOk.Location = new Point(50, 70);

                Button buttonCancel = new Button();
                buttonCancel.Text = "Cancel";
                buttonCancel.DialogResult = DialogResult.Cancel;
                buttonCancel.Location = new Point(150, 70);

                form.Controls.Add(label);
                form.Controls.Add(comboBoxStatus);
                form.Controls.Add(buttonOk);
                form.Controls.Add(buttonCancel);

                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    newStatus = comboBoxStatus.SelectedItem.ToString();
                }
            }

            return newStatus;
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
        {
            string query = "UPDATE orders SET status = @status WHERE id = @orderId";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@status", newStatus);
                command.Parameters.AddWithValue("@orderId", orderId);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Статус заказа успешно обновлен!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении статуса заказа: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                int orderId = (int)dataGridViewOrders.SelectedRows[0].Cells["id"].Value;

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот заказ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteOrder(orderId);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для удаления.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteOrder(int orderId)
        {
            string query = "DELETE FROM orders WHERE id = @orderId";

            using (MySqlCommand command = new MySqlCommand(query, SQLConnection.connection))
            {
                command.Parameters.AddWithValue("@orderId", orderId);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Заказ успешно удален!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders(); // Обновить список заказов после удаления
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении заказа: {ex.Message}", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

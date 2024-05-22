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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BD_1
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            comboBoxStatus.Items.AddRange(new object[] { "pending", "in production", "ready", "collected" });
            comboBoxStatus.SelectedIndex = 0;
            comboBoxType.Items.AddRange(new object[] { "готовые", "микстура", "мазь", "раствор", "порошок" });
            comboBoxType.SelectedIndex = 0;
            comboBoxReportType.Items.AddRange(new object[] { "Запрос 1", "Запрос 1.2", "Запрос 2", "Запрос 2.2", "Запрос 3", "Запрос 3.2", "Запрос 4", "Запрос 5", "Запрос 6", "Запрос 7", "Запрос 8", "Запрос 9", "Запрос 10", "Запрос 11", "Запрос 12", "Запрос 13" });
            comboBoxReportType.SelectedIndex = 0;
        }

        private void ButtonGenerateReport_Click(object sender, EventArgs e)
        {
            string reportType = comboBoxReportType.SelectedItem.ToString();
            string query = "";

            switch (reportType)
            {
                case "Запрос 1":
                    query = @$"SELECT p.*
                            FROM patients p
                            INNER JOIN orders o ON p.id = o.patient_id
                            WHERE o.status = '{comboBoxStatus.SelectedItem}' AND o.collection_time < NOW()
                            ";
                    break;
                case "Запрос 1.2":
                    query = @$"SELECT COUNT(*)
                            FROM patients p
                            INNER JOIN orders o ON p.id = o.patient_id
                            WHERE o.status = {comboBoxStatus.SelectedValue} AND o.collection_time < NOW()
                            ";
                    break;
                case "Запрос 2":
                    query = @$"SELECT p.*, COUNT(*) as total_waiting
                            FROM patients p
                            INNER JOIN orders o ON p.id = o.patient_id
                            WHERE o.status = {comboBoxStatus.SelectedValue}
                            GROUP BY p.id
                            ";
                    break;
                case "Запрос 2.2":
                    query = @$"SELECT p.*, COUNT(*) as total_waiting
                            FROM patients p
                            INNER JOIN orders o ON p.id = o.patient_id
                            INNER JOIN prescriptions pr ON o.prescription_id = pr.id
                            INNER JOIN medications m ON pr.medication_id = m.id
                            WHERE o.status = {comboBoxStatus.SelectedValue} AND m.type = {comboBoxReportType.SelectedItem}
                            GROUP BY p.id
                            ";
                    break;
                case "Запрос 3":
                    query = @$"SELECT m.name, COUNT(*) as total_usage
                            FROM medications m
                            INNER JOIN prescriptions pr ON m.id = pr.medication_id
                            GROUP BY m.id
                            ORDER BY total_usage DESC
                            LIMIT 10
                            ";
                    break;
                case "Запрос 3.2":
                    query = @$"SELECT m.name, COUNT(*) as total_usage
                            FROM medications m
                            INNER JOIN prescriptions pr ON m.id = pr.medication_id
                            WHERE m.type = {comboBoxReportType.SelectedItem}
                            GROUP BY m.id
                            ORDER BY total_usage DESC
                            LIMIT 10
                            ";
                    break;
                case "Запрос 4":
                    query = @$"SELECT SUM(quantity) AS total_used
                            FROM inventory_log
                            WHERE ingredient_id = 'идентификатор_вещества'
                              AND timestamp BETWEEN 'начальная_дата' AND 'конечная_дата'
                            ";
                    break;
                case "Запрос 5":
                    query = @$"SELECT p.*, COUNT(*) as total_orders
                            FROM patients p
                            INNER JOIN orders o ON p.id = o.patient_id
                            INNER JOIN prescriptions pr ON o.prescription_id = pr.id
                            INNER JOIN medications m ON pr.medication_id = m.id
                            WHERE m.name = 'указанное_лекарство'
                                OR m.type IN ('тип_лекарства1', 'тип_лекарства2')
                                AND o.order_time BETWEEN 'начальная_дата' AND 'конечная_дата'
                            GROUP BY p.id
                            ";
                    break;
                case "Запрос 6":
                    query = @$"
                            SELECT m.name, m.type
                            FROM medications m
                            INNER JOIN ingredients i ON m.id = i.id
                            WHERE i.stock <= i.critical_level
                            ";
                    break;
                case "Запрос 7":
                    query = @$"SELECT m.name, m.type
                            FROM medications m
                            INNER JOIN medication_ingredients mi ON m.id = mi.medication_id
                            INNER JOIN ingredients i ON mi.ingredient_id = i.id
                            GROUP BY m.id
                            HAVING MIN(i.stock) <= 10
                            ";
                    break;
                case "Запрос 8":
                    query = @$"SELECT *
                            FROM orders
                            WHERE status = 'in production'
                            ";
                    break;
                case "Запрос 9":
                    query = @$"SELECT DISTINCT pr.*
                            FROM prescriptions pr
                            INNER JOIN orders o ON pr.id = o.prescription_id
                            WHERE o.status = 'in production'
                            ";
                    break;
                case "Запрос 10":
                    query = @$"SELECT DISTINCT pm.*
                            FROM preparation_methods pm
                            INNER JOIN medications m ON pm.id = m.preparation_method_id
                            INNER JOIN medication_ingredients mi ON m.id = mi.medication_id
                            INNER JOIN orders o ON m.id = o.prescription_id
                            WHERE o.status = 'in production'
                            ";
                    break;
                case "Запрос 11":
                    query = @$"
                            SELECT m.name AS medication_name, m.price AS medication_price,
                                    i.name AS ingredient_name, mi.quantity, i.price AS ingredient_price
                            FROM medications m
                            INNER JOIN medication_ingredients mi ON m.id = mi.medication_id
                            INNER JOIN ingredients i ON mi.ingredient_id = i.id
                            WHERE m.name = 'указанное_лекарство'
                            ";
                    break;
                case "Запрос 12":
                    query = @$"
                            SELECT p.*, COUNT(*) AS total_orders
                            FROM patients p
                            INNER JOIN orders o ON p.id = o.patient_id
                            GROUP BY p.id
                            HAVING total_orders > 5 -- Предположим, что 5 - это минимальное количество заказов для считания пациента постоянным клиентом
                            ";
                    break;
                case "Запрос 13":
                    query = @$"
                            SELECT m.name AS medication_name, m.type AS medication_type, pm.method_name AS preparation_method,
                                   GROUP_CONCAT(i.name) AS ingredients, m.price AS medication_price, 
                                   SUM(i.stock) AS total_stock
                            FROM medications m
                            INNER JOIN preparation_methods pm ON m.preparation_method_id = pm.id
                            INNER JOIN medication_ingredients mi ON m.id = mi.medication_id
                            INNER JOIN ingredients i ON mi.ingredient_id = i.id
                            WHERE m.name = 'указанное_лекарство'
                            GROUP BY m.id
                            ";
                    break;
                default:
                    MessageBox.Show("Invalid report type selected.");
                    return;
            }

            DataTable reportData = ExecuteSelectQuery(query);
            dataGridViewReport.DataSource = reportData;
        }

        private DataTable ExecuteSelectQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, SQLConnection.connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dataTable;
        }
    }
}

using MySql.Data.MySqlClient;

namespace BD_1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Успешный вход!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            try
            {
                string connectionString = $"server=127.0.0.1;port=3306;user={username};password={password};database=pharmacyv2;";
                SQLConnection.connection = new MySqlConnection(connectionString);
                SQLConnection.connection.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
    }
}

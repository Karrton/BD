using MySql.Data.MySqlClient;

namespace BD_1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
            Application.Exit();
            SQLConnection.connection.Close();
        }
    }
}
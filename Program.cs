using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Project_1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

                bool validConnection = false;

            while (!validConnection)
            {
                DatabaseConnection form1 = new DatabaseConnection();
                if (form1.ShowDialog() == DialogResult.OK)
                {
                    string connectionString = form1.Tag.ToString();

                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open(); // Try to open the connection to validate it
                            validConnection = true;
                        }

                        DatabaseService form2 = new DatabaseService();
                        form2.LoadTableNames(connectionString);
                        Application.Run(form2); // Run the DatabaseService form
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to connect to the database. Please check your inputs and try again.\nError: " + ex.Message);
                    }
                }
                else
                {
                    // If user cancels DatabaseConnection, exit the application
                    Application.Exit();
                    return;
                }
            }
        }
    }
}
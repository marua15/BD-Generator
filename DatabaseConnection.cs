using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_1
{
    public partial class DatabaseConnection : Form
    {
        public DatabaseConnection()
        {
            InitializeComponent();
        }

        internal string GetConnectionString()
        {
            string host = textBoxHost.Text.Trim();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please fill in all required fields (Host, Username).");
                return null;
            }

            string connectionString;
            if (string.IsNullOrWhiteSpace(password))
            {
                connectionString = $"Server={host};Uid={username};";
            }
            else
            {
                connectionString = $"Server={host};Uid={username};Pwd={password};";
            }

            return connectionString;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            if (!string.IsNullOrEmpty(connectionString))
            {
                List<string> databases = GetDatabases(connectionString);
                if (databases != null)
                {
                    comboBoxDatabase.Items.Clear();
                    foreach (var db in databases)
                    {
                        comboBoxDatabase.Items.Add(db);
                    }
                }
            }
        }

        private List<string> GetDatabases(string connectionString)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var databases = new List<string>();
                    var command = new MySqlCommand("SHOW DATABASES", connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            databases.Add(reader.GetString(0));
                        }
                    }
                    return databases;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve databases: " + ex.Message);
                return null;
            }
        }

        private void buttonSelectDatabase_Click(object sender, EventArgs e)
        {
            string host = textBoxHost.Text.Trim();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string database = comboBoxDatabase.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(database))
            {
                MessageBox.Show("Please fill in all required fields (Host, Username, Database).");
                return;
            }

            string connectionString;
            if (string.IsNullOrWhiteSpace(password))
            {
                connectionString = $"Server={host};Database={database};Uid={username};";
            }
            else
            {
                connectionString = $"Server={host};Database={database};Uid={username};Pwd={password};";
            }

            this.Tag = connectionString; // Store connection string in Tag
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

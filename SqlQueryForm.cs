using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_1
{
    public partial class SqlQueryForm : Form
    {
        public event EventHandler QueryExecuted;

        private string connectionString;

        public SqlQueryForm(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            string query = textBoxSqlQuery.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridViewResults.DataSource = dataTable;

                    // Trigger the event after successfully executing the query
                    QueryExecuted?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while executing the query: " + ex.Message);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSqlQuery.Text = ""; // Clear the SQL query text box
            dataGridViewResults.DataSource = null; // Clear the data grid view
        }
    }
}

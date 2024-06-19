using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_1
{
    public partial class DatabaseService : Form
    {
        private string connectionString;
        private DataTable schemaTable;
        private TextBox[] inputBoxes;
        private bool inputControlsCreated = false;

     
        public DatabaseService()
        {
            InitializeComponent();
            this.buttonConfirmAdd.Visible = false;
            this.buttonConfirmUpdate.Visible = false;
            this.buttonConfirmDelete.Visible = false;

            this.buttonExecuteSQL.Click += buttonExecuteSQL_Click;
            this.buttonClearSession.Click += buttonClearSession_Click;
            this.buttonLogout.Click += buttonLogout_Click;
            this.Load += DatabaseService_Load;
        }

        private void buttonExecuteSQL_Click(object sender, EventArgs e)
        {
            // Instantiate and show the SqlQueryForm
            SqlQueryForm sqlForm = new SqlQueryForm(connectionString);

            // Subscribe to the QueryExecuted event
            sqlForm.QueryExecuted += SqlForm_QueryExecuted;

            sqlForm.ShowDialog(); // Show dialog to wait for form closure
        }
        // Event handler to reload table names when a query is executed
        private void SqlForm_QueryExecuted(object sender, EventArgs e)
        {
            LoadTableNames(connectionString);
        }


        private void buttonLogout_Click(object sender, EventArgs e)
        {
            ClearSession();

            // Hide the current form (DatabaseService)
            this.Hide();

            // Show the database connection form
            DatabaseConnection dbConnectionForm = new DatabaseConnection();
            dbConnectionForm.FormClosed += (s, args) =>
            {
                // This event handler ensures that the main form (DatabaseService) is shown again after database connection
                if (dbConnectionForm.DialogResult == DialogResult.OK)
                {
                    this.connectionString = dbConnectionForm.Tag.ToString(); // Retrieve connection string from DatabaseConnection form
                    this.Show(); // Show the DatabaseService form again
                    LoadTableNames(connectionString);
                }
                else
                {
                    this.Close(); // Close the main form if database connection form is closed without selecting a database
                }
            };

            // Show the database connection form as a modal dialog
            dbConnectionForm.ShowDialog();
        }


        private void ClearSession()
        {
            schemaTable = null;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            panelInputs.Controls.Clear();
            inputBoxes = null;
            inputControlsCreated = false;
            comboBoxTables.Items.Clear();
        }

        private void SqlQueryForm_QueryExecuted(object sender, EventArgs e)
        {
            LoadTableNames(connectionString);
        }

        private void DatabaseService_Load(object sender, EventArgs e)
        {
            // Optionally, load initial data if needed
        }

        public void LoadTableNames(string connectionString)
        {
            this.connectionString = connectionString;
            comboBoxTables.Items.Clear();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable dt = connection.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        comboBoxTables.Items.Add(tableName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void buttonClearSession_Click(object sender, EventArgs e)
        {
            ClearSession();
        }

        private void buttonShowSchema_Click(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedTableName))
            {
                MessageBox.Show("Please select a table before showing schema.");
                return;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string is not set.");
                return;
            }

            panelInputs.Visible = false;
            LoadTableSchema(connectionString, selectedTableName);
        }

        private void LoadTableSchema(string connectionString, string tableName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string schemaQuery = $"SHOW COLUMNS FROM {tableName}";
                    MySqlCommand schemaCmd = new MySqlCommand(schemaQuery, connection);
                    MySqlDataAdapter schemaAdapter = new MySqlDataAdapter(schemaCmd);
                    schemaTable = new DataTable();
                    schemaAdapter.Fill(schemaTable);

                    dataGridView1.Columns.Clear();

                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string columnName = row["Field"].ToString();
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                        {
                            Name = columnName,
                            HeaderText = columnName,
                            DataPropertyName = columnName
                        };
                        dataGridView1.Columns.Add(column);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void DisplayTableData(string connectionString, string tableName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = $"SELECT * FROM {tableName}";
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading data: " + ex.Message);
                }
            }
        }

        private void CreateInputControls()
        {
            panelInputs.Controls.Clear();
            inputBoxes = new TextBox[schemaTable.Rows.Count];
            int y = 10;
            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {
                string columnName = schemaTable.Rows[i]["Field"].ToString();

                Label label = new Label
                {
                    Text = columnName,
                    Location = new System.Drawing.Point(10, y),
                    AutoSize = true
                };
                panelInputs.Controls.Add(label);

                TextBox textBox = new TextBox
                {
                    Name = $"textBox_{columnName}",
                    Location = new System.Drawing.Point(120, y),
                    Width = 200
                };
                panelInputs.Controls.Add(textBox);

                inputBoxes[i] = textBox;
                y += 30;
            }

            inputControlsCreated = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedTableName))
            {
                MessageBox.Show("Please select a table before adding data.");
                return;
            }

            panelInputs.Visible = true;
            buttonConfirmAdd.Visible = true;
            buttonConfirmUpdate.Visible = false;
            buttonConfirmDelete.Visible = false;

            if (!inputControlsCreated)
            {
                CreateInputControls();
            }
            else
            {
                foreach (TextBox textBox in inputBoxes)
                {
                    textBox.Text = "";
                }
            }
        }

        private void buttonConfirmAdd_Click(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedTableName))
            {
                MessageBox.Show("Please select a table before confirming addition.");
                return;
            }

            AddNewRecord(connectionString, selectedTableName);

            buttonConfirmAdd.Visible = false;
        }

        private void AddNewRecord(string connectionString, string tableName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string columns = string.Join(", ", schemaTable.Rows.Cast<DataRow>().Select(row => row["Field"].ToString()));
                    string values = string.Join(", ", inputBoxes.Select(textBox => $"'{SanitizeInput(textBox.Text)}'"));
                    string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record added successfully.");

                    LoadTableSchema(connectionString, tableName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedTableName))
            {
                MessageBox.Show("Please select a table before updating data.");
                return;
            }

            panelInputs.Visible = true;
            buttonConfirmAdd.Visible = false;
            buttonConfirmUpdate.Visible = true;
            buttonConfirmDelete.Visible = false;

            if (!inputControlsCreated)
            {
                CreateInputControls();
            }
            else
            {
                foreach (TextBox textBox in inputBoxes)
                {
                    textBox.Text = "";
                }
            }
        }

        private void buttonConfirmUpdate_Click(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedTableName))
            {
                MessageBox.Show("Please select a table before confirming update.");
                return;
            }

            string primaryKeyColumn = schemaTable.Rows[0]["Field"].ToString(); // Assuming the first column is the primary key
            UpdateRecord(connectionString, selectedTableName, primaryKeyColumn);

            buttonConfirmUpdate.Visible = false;
        }

        private void UpdateRecord(string connectionString, string tableName, string primaryKeyColumn)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateSet = string.Join(", ", schemaTable.Rows.Cast<DataRow>().Select(row => $"{row["Field"]} = '{SanitizeInput(inputBoxes[schemaTable.Rows.IndexOf(row)].Text)}'"));
                    string primaryKeyValue = SanitizeInput(inputBoxes[schemaTable.Rows.Cast<DataRow>().ToList().FindIndex(row => row["Field"].ToString() == primaryKeyColumn)].Text);
                    string updateQuery = $"UPDATE {tableName} SET {updateSet} WHERE {primaryKeyColumn} = '{primaryKeyValue}'";

                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record updated successfully.");

                    LoadTableSchema(connectionString, tableName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedTableName))
            {
                MessageBox.Show("Please select a table before deleting data.");
                return;
            }

            panelInputs.Visible = true;
            buttonConfirmAdd.Visible = false;
            buttonConfirmUpdate.Visible = false;
            buttonConfirmDelete.Visible = true;

            if (!inputControlsCreated)
            {
                CreateInputControls();
            }
            else
            {
                foreach (TextBox textBox in inputBoxes)
                {
                    textBox.Text = "";
                }
            }
        }

        private void buttonConfirmDelete_Click(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedTableName))
            {
                MessageBox.Show("Please select a table before confirming deletion.");
                return;
            }

            string primaryKeyColumn = schemaTable.Rows[0]["Field"].ToString(); // Assuming the first column is the primary key
            DeleteRecord(connectionString, selectedTableName, primaryKeyColumn);

            buttonConfirmDelete.Visible = false;
        }

        private void DeleteRecord(string connectionString, string tableName, string primaryKeyColumn)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string primaryKeyValue = SanitizeInput(inputBoxes[schemaTable.Rows.Cast<DataRow>().ToList().FindIndex(row => row["Field"].ToString() == primaryKeyColumn)].Text);
                    string deleteQuery = $"DELETE FROM {tableName} WHERE {primaryKeyColumn} = '{primaryKeyValue}'";

                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record deleted successfully.");

                    LoadTableSchema(connectionString, tableName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedTableName))
            {
                MessageBox.Show("Please select a table before loading data.");
                return;
            }

            panelInputs.Visible = false;
            DisplayTableData(connectionString, selectedTableName);
        }

        private string SanitizeInput(string input)
        {
            // Implement sanitization logic as needed (e.g., escaping characters)
            return input.Replace("'", "''"); // Escape single quotes for MySQL
        }
    }
}
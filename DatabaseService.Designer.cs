namespace Project_1
{
    partial class DatabaseService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Button buttonShowSchema;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelInputs;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.Button buttonConfirmAdd;
        private System.Windows.Forms.Button buttonConfirmUpdate;
        private System.Windows.Forms.Button buttonConfirmDelete;
        private System.Windows.Forms.Button buttonExecuteSQL;
        private System.Windows.Forms.Button buttonClearSession;
        private System.Windows.Forms.Button buttonLogout;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
private void InitializeComponent()
        {
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.buttonShowSchema = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelInputs = new System.Windows.Forms.Panel();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.buttonConfirmAdd = new System.Windows.Forms.Button();
            this.buttonConfirmUpdate = new System.Windows.Forms.Button();
            this.buttonConfirmDelete = new System.Windows.Forms.Button();
            this.buttonExecuteSQL = new System.Windows.Forms.Button();
            this.buttonClearSession = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(12, 12);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(150, 21);
            this.comboBoxTables.TabIndex = 0;
            // 
            // buttonShowSchema
            // 
            this.buttonShowSchema.Location = new System.Drawing.Point(12, 39);
            this.buttonShowSchema.Name = "buttonShowSchema";
            this.buttonShowSchema.Size = new System.Drawing.Size(150, 23);
            this.buttonShowSchema.TabIndex = 1;
            this.buttonShowSchema.Text = "Show Schema";
            this.buttonShowSchema.UseVisualStyleBackColor = true;
            this.buttonShowSchema.Click += new System.EventHandler(this.buttonShowSchema_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 68);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add Data";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(12, 97);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(150, 23);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Update Data";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 126);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(150, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete Data";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Location = new System.Drawing.Point(12, 155);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(150, 23);
            this.buttonLoadData.TabIndex = 5;
            this.buttonLoadData.Text = "Load Data";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // buttonExecuteSQL
            // 
            this.buttonExecuteSQL.Location = new System.Drawing.Point(12, 184);
            this.buttonExecuteSQL.Name = "buttonExecuteSQL";
            this.buttonExecuteSQL.Size = new System.Drawing.Size(150, 23);
            this.buttonExecuteSQL.TabIndex = 11;
            this.buttonExecuteSQL.Text = "Execute SQL Query";
            this.buttonExecuteSQL.UseVisualStyleBackColor = true;
            this.buttonExecuteSQL.Click += new System.EventHandler(this.buttonExecuteSQL_Click);
            // 
            // buttonClearSession
            // 
            this.buttonClearSession.Location = new System.Drawing.Point(12, 213);
            this.buttonClearSession.Name = "buttonClearSession";
            this.buttonClearSession.Size = new System.Drawing.Size(150, 23);
            this.buttonClearSession.TabIndex = 12;
            this.buttonClearSession.Text = "Clear Session";
            this.buttonClearSession.UseVisualStyleBackColor = true;
            this.buttonClearSession.Click += new System.EventHandler(this.buttonClearSession_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(12, 242);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(150, 23);
            this.buttonLogout.TabIndex = 13;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(168, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(620, 300);
            this.dataGridView1.TabIndex = 3;
            // 
            // panelInputs
            // 
            this.panelInputs.AutoScroll = true;
            this.panelInputs.Location = new System.Drawing.Point(168, 318);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(620, 150);
            this.panelInputs.TabIndex = 4;
            this.panelInputs.Visible = false; // Initially hidden
                                              // 
                                              // buttonConfirmAdd
                                              // 
            this.buttonConfirmAdd.Location = new System.Drawing.Point(168, 474);
            this.buttonConfirmAdd.Name = "buttonConfirmAdd";
            this.buttonConfirmAdd.Size = new System.Drawing.Size(100, 23);
            this.buttonConfirmAdd.TabIndex = 8;
            this.buttonConfirmAdd.Text = "Confirm Add";
            this.buttonConfirmAdd.UseVisualStyleBackColor = true;
            this.buttonConfirmAdd.Click += new System.EventHandler(this.buttonConfirmAdd_Click);
            // 
            // buttonConfirmUpdate
            // 
            this.buttonConfirmUpdate.Location = new System.Drawing.Point(274, 474);
            this.buttonConfirmUpdate.Name = "buttonConfirmUpdate";
            this.buttonConfirmUpdate.Size = new System.Drawing.Size(120, 23);
            this.buttonConfirmUpdate.TabIndex = 9;
            this.buttonConfirmUpdate.Text = "Confirm Update";
            this.buttonConfirmUpdate.UseVisualStyleBackColor = true;
            this.buttonConfirmUpdate.Click += new System.EventHandler(this.buttonConfirmUpdate_Click);
            // 
            // buttonConfirmDelete
            // 
            this.buttonConfirmDelete.Location = new System.Drawing.Point(400, 474);
            this.buttonConfirmDelete.Name = "buttonConfirmDelete";
            this.buttonConfirmDelete.Size = new System.Drawing.Size(120, 23);
            this.buttonConfirmDelete.TabIndex = 10;
            this.buttonConfirmDelete.Text = "Confirm Delete";
            this.buttonConfirmDelete.UseVisualStyleBackColor = true;
            this.buttonConfirmDelete.Click += new System.EventHandler(this.buttonConfirmDelete_Click);
            // 
            // DatabaseService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.buttonConfirmDelete);
            this.Controls.Add(this.buttonConfirmUpdate);
            this.Controls.Add(this.buttonConfirmAdd);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonShowSchema);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.buttonLoadData);
            this.Controls.Add(this.buttonExecuteSQL);
            this.Controls.Add(this.buttonClearSession);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Name = "DatabaseService";
            this.Text = "DatabaseService";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
namespace JohnSands.QuickBase.Sample {
    partial class SampleForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnGetSchemas = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnRunQuery = new System.Windows.Forms.Button();
            this.lblQueryNum = new System.Windows.Forms.Label();
            this.txtDebugLocation = new System.Windows.Forms.TextBox();
            this.chkWriteDebug = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabQueryResult = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboQuery = new System.Windows.Forms.ComboBox();
            this.tabSchemas = new System.Windows.Forms.TabPage();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.btnRefreshSchemas = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.queryResults = new JohnSands.QuickBase.Sample.QueryResultPanel();
            this.schemaInfoPanel1 = new JohnSands.QuickBase.Sample.SchemaInfoPanel();
            this.tabControl1.SuspendLayout();
            this.tabQueryResult.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabSchemas.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetSchemas
            // 
            this.btnGetSchemas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGetSchemas.Enabled = false;
            this.btnGetSchemas.Location = new System.Drawing.Point(633, 118);
            this.btnGetSchemas.Name = "btnGetSchemas";
            this.btnGetSchemas.Size = new System.Drawing.Size(75, 23);
            this.btnGetSchemas.TabIndex = 1;
            this.btnGetSchemas.Text = "Get Schema";
            this.btnGetSchemas.UseVisualStyleBackColor = true;
            this.btnGetSchemas.Click += new System.EventHandler(this.DoGetSchemas);
            // 
            // lblUrl
            // 
            this.lblUrl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(67, 11);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(36, 39);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(43, 68);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.AutoWordSelection = true;
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(96)))));
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtOutput.HideSelection = false;
            this.txtOutput.Location = new System.Drawing.Point(6, 6);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(680, 347);
            this.txtOutput.TabIndex = 9;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // btnRunQuery
            // 
            this.btnRunQuery.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRunQuery.Enabled = false;
            this.btnRunQuery.Location = new System.Drawing.Point(245, 3);
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(75, 23);
            this.btnRunQuery.TabIndex = 12;
            this.btnRunQuery.Text = "Run Query";
            this.btnRunQuery.UseVisualStyleBackColor = true;
            this.btnRunQuery.Click += new System.EventHandler(this.DoPerformQuery);
            // 
            // lblQueryNum
            // 
            this.lblQueryNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQueryNum.AutoSize = true;
            this.lblQueryNum.Location = new System.Drawing.Point(3, 8);
            this.lblQueryNum.Name = "lblQueryNum";
            this.lblQueryNum.Size = new System.Drawing.Size(35, 13);
            this.lblQueryNum.TabIndex = 13;
            this.lblQueryNum.Text = "Query";
            // 
            // txtDebugLocation
            // 
            this.txtDebugLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtDebugLocation, 2);
            this.txtDebugLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "DebuggingLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDebugLocation.Location = new System.Drawing.Point(202, 92);
            this.txtDebugLocation.Name = "txtDebugLocation";
            this.txtDebugLocation.Size = new System.Drawing.Size(425, 20);
            this.txtDebugLocation.TabIndex = 16;
            this.txtDebugLocation.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.DebuggingLocation;
            this.txtDebugLocation.Click += new System.EventHandler(this.DoLocationClicked);
            // 
            // chkWriteDebug
            // 
            this.chkWriteDebug.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkWriteDebug.AutoSize = true;
            this.chkWriteDebug.Checked = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.DebuggingEnabled;
            this.tableLayoutPanel2.SetColumnSpan(this.chkWriteDebug, 2);
            this.chkWriteDebug.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "DebuggingEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkWriteDebug.Location = new System.Drawing.Point(10, 93);
            this.chkWriteDebug.Name = "chkWriteDebug";
            this.chkWriteDebug.Size = new System.Drawing.Size(186, 17);
            this.chkWriteDebug.TabIndex = 15;
            this.chkWriteDebug.Text = "Write Debugging Files to Location";
            this.chkWriteDebug.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtPassword, 3);
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBasePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPassword.Location = new System.Drawing.Point(102, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(525, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBasePassword;
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtUserName, 3);
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBaseUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUserName.Location = new System.Drawing.Point(102, 35);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(525, 20);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBaseUser;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtUrl, 3);
            this.txtUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBaseUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUrl.Location = new System.Drawing.Point(102, 8);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(525, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBaseUrl;
            // 
            // tabControl1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tabControl1, 5);
            this.tabControl1.Controls.Add(this.tabQueryResult);
            this.tabControl1.Controls.Add(this.tabSchemas);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(8, 147);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 364);
            this.tabControl1.TabIndex = 17;
            // 
            // tabQueryResult
            // 
            this.tabQueryResult.Controls.Add(this.tableLayoutPanel1);
            this.tabQueryResult.Location = new System.Drawing.Point(4, 22);
            this.tabQueryResult.Name = "tabQueryResult";
            this.tabQueryResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabQueryResult.Size = new System.Drawing.Size(692, 338);
            this.tabQueryResult.TabIndex = 1;
            this.tabQueryResult.Text = "Query Result";
            this.tabQueryResult.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblQueryNum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.queryResults, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboQuery, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRunQuery, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(686, 332);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // comboQuery
            // 
            this.comboQuery.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuery.Enabled = false;
            this.comboQuery.FormattingEnabled = true;
            this.comboQuery.Location = new System.Drawing.Point(44, 4);
            this.comboQuery.Name = "comboQuery";
            this.comboQuery.Size = new System.Drawing.Size(195, 21);
            this.comboQuery.TabIndex = 15;
            // 
            // tabSchemas
            // 
            this.tabSchemas.Controls.Add(this.schemaInfoPanel1);
            this.tabSchemas.Location = new System.Drawing.Point(4, 22);
            this.tabSchemas.Name = "tabSchemas";
            this.tabSchemas.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchemas.Size = new System.Drawing.Size(692, 338);
            this.tabSchemas.TabIndex = 2;
            this.tabSchemas.Text = "Schemas";
            this.tabSchemas.UseVisualStyleBackColor = true;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtOutput);
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(692, 338);
            this.tabLog.TabIndex = 0;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // btnRefreshSchemas
            // 
            this.btnRefreshSchemas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRefreshSchemas.Enabled = false;
            this.btnRefreshSchemas.Location = new System.Drawing.Point(552, 118);
            this.btnRefreshSchemas.Name = "btnRefreshSchemas";
            this.btnRefreshSchemas.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSchemas.TabIndex = 2;
            this.btnRefreshSchemas.Text = "Refresh";
            this.btnRefreshSchemas.UseVisualStyleBackColor = true;
            this.btnRefreshSchemas.Click += new System.EventHandler(this.DoRefreshSchemas);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.comboBox1, 2);
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(102, 119);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(444, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.DoSelectedDbChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database/Table:";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSignIn.Location = new System.Drawing.Point(633, 34);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 18;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.DoSignIn);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSignOut.Enabled = false;
            this.btnSignOut.Location = new System.Drawing.Point(633, 63);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(75, 23);
            this.btnSignOut.TabIndex = 19;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.DoSignOut);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressStatus,
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(716, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressStatus
            // 
            this.progressStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(100, 16);
            this.progressStatus.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnSignOut, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnRefreshSchemas, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnGetSchemas, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblPassword, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkWriteDebug, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblUserName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDebugLocation, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtUrl, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtUserName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPassword, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblUrl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSignIn, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(716, 514);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // queryResults
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.queryResults, 3);
            this.queryResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryResults.Location = new System.Drawing.Point(3, 32);
            this.queryResults.Name = "queryResults";
            this.queryResults.Size = new System.Drawing.Size(680, 297);
            this.queryResults.TabIndex = 0;
            // 
            // schemaInfoPanel1
            // 
            this.schemaInfoPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.schemaInfoPanel1.Location = new System.Drawing.Point(6, 6);
            this.schemaInfoPanel1.Name = "schemaInfoPanel1";
            this.schemaInfoPanel1.Size = new System.Drawing.Size(680, 187);
            this.schemaInfoPanel1.TabIndex = 0;
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 536);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.Location = new System.Drawing.Point(150, 150);
            this.Name = "SampleForm";
            this.Text = "SampleForm";
            this.Load += new System.EventHandler(this.DoFormLoaded);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoFormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabQueryResult.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabSchemas.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGetSchemas;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnRunQuery;
        private System.Windows.Forms.Label lblQueryNum;
        private System.Windows.Forms.CheckBox chkWriteDebug;
        private System.Windows.Forms.TextBox txtDebugLocation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabQueryResult;
        private QueryResultPanel queryResults;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.TabPage tabSchemas;
        private System.Windows.Forms.Button btnRefreshSchemas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private SchemaInfoPanel schemaInfoPanel1;
        private System.Windows.Forms.ComboBox comboQuery;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressStatus;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
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
            this.tabSchemas = new System.Windows.Forms.TabPage();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.btnRefreshSchemas = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.comboQuery = new System.Windows.Forms.ComboBox();
            this.queryResults = new JohnSands.QuickBase.Sample.QueryResultPanel();
            this.schemaInfoPanel1 = new JohnSands.QuickBase.Sample.SchemaInfoPanel();
            this.tabControl1.SuspendLayout();
            this.tabQueryResult.SuspendLayout();
            this.tabSchemas.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetSchemas
            // 
            this.btnGetSchemas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetSchemas.Enabled = false;
            this.btnGetSchemas.Location = new System.Drawing.Point(655, 115);
            this.btnGetSchemas.Name = "btnGetSchemas";
            this.btnGetSchemas.Size = new System.Drawing.Size(75, 23);
            this.btnGetSchemas.TabIndex = 1;
            this.btnGetSchemas.Text = "Get Schema";
            this.btnGetSchemas.UseVisualStyleBackColor = true;
            this.btnGetSchemas.Click += new System.EventHandler(this.DoGetSchemas);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 15);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 41);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 67);
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
            this.txtOutput.Size = new System.Drawing.Size(698, 378);
            this.txtOutput.TabIndex = 9;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // btnRunQuery
            // 
            this.btnRunQuery.Enabled = false;
            this.btnRunQuery.Location = new System.Drawing.Point(258, 4);
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(75, 23);
            this.btnRunQuery.TabIndex = 12;
            this.btnRunQuery.Text = "Run Query";
            this.btnRunQuery.UseVisualStyleBackColor = true;
            this.btnRunQuery.Click += new System.EventHandler(this.DoPerformQuery);
            // 
            // lblQueryNum
            // 
            this.lblQueryNum.AutoSize = true;
            this.lblQueryNum.Location = new System.Drawing.Point(6, 9);
            this.lblQueryNum.Name = "lblQueryNum";
            this.lblQueryNum.Size = new System.Drawing.Size(45, 13);
            this.lblQueryNum.TabIndex = 13;
            this.lblQueryNum.Text = "Query #";
            // 
            // txtDebugLocation
            // 
            this.txtDebugLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "DebuggingLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDebugLocation.Location = new System.Drawing.Point(204, 91);
            this.txtDebugLocation.Name = "txtDebugLocation";
            this.txtDebugLocation.Size = new System.Drawing.Size(526, 20);
            this.txtDebugLocation.TabIndex = 16;
            this.txtDebugLocation.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.DebuggingLocation;
            this.txtDebugLocation.Click += new System.EventHandler(this.DoLocationClicked);
            // 
            // chkWriteDebug
            // 
            this.chkWriteDebug.AutoSize = true;
            this.chkWriteDebug.Checked = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.DebuggingEnabled;
            this.chkWriteDebug.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "DebuggingEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkWriteDebug.Location = new System.Drawing.Point(15, 93);
            this.chkWriteDebug.Name = "chkWriteDebug";
            this.chkWriteDebug.Size = new System.Drawing.Size(186, 17);
            this.chkWriteDebug.TabIndex = 15;
            this.chkWriteDebug.Text = "Write Debugging Files to Location";
            this.chkWriteDebug.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBasePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPassword.Location = new System.Drawing.Point(78, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(529, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBasePassword;
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBaseUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUserName.Location = new System.Drawing.Point(78, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(529, 20);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBaseUser;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBaseUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUrl.Location = new System.Drawing.Point(78, 12);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(652, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBaseUrl;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabQueryResult);
            this.tabControl1.Controls.Add(this.tabSchemas);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Location = new System.Drawing.Point(12, 144);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 416);
            this.tabControl1.TabIndex = 17;
            // 
            // tabQueryResult
            // 
            this.tabQueryResult.Controls.Add(this.comboQuery);
            this.tabQueryResult.Controls.Add(this.queryResults);
            this.tabQueryResult.Controls.Add(this.lblQueryNum);
            this.tabQueryResult.Controls.Add(this.btnRunQuery);
            this.tabQueryResult.Location = new System.Drawing.Point(4, 22);
            this.tabQueryResult.Name = "tabQueryResult";
            this.tabQueryResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabQueryResult.Size = new System.Drawing.Size(710, 390);
            this.tabQueryResult.TabIndex = 1;
            this.tabQueryResult.Text = "Query Result";
            this.tabQueryResult.UseVisualStyleBackColor = true;
            // 
            // tabSchemas
            // 
            this.tabSchemas.Controls.Add(this.schemaInfoPanel1);
            this.tabSchemas.Location = new System.Drawing.Point(4, 22);
            this.tabSchemas.Name = "tabSchemas";
            this.tabSchemas.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchemas.Size = new System.Drawing.Size(710, 390);
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
            this.tabLog.Size = new System.Drawing.Size(710, 390);
            this.tabLog.TabIndex = 0;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // btnRefreshSchemas
            // 
            this.btnRefreshSchemas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshSchemas.Enabled = false;
            this.btnRefreshSchemas.Location = new System.Drawing.Point(574, 115);
            this.btnRefreshSchemas.Name = "btnRefreshSchemas";
            this.btnRefreshSchemas.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSchemas.TabIndex = 2;
            this.btnRefreshSchemas.Text = "Refresh";
            this.btnRefreshSchemas.UseVisualStyleBackColor = true;
            this.btnRefreshSchemas.Click += new System.EventHandler(this.DoRefreshSchemas);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(107, 117);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(461, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.DoSelectedDbChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database/Table:";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignIn.Location = new System.Drawing.Point(613, 36);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(117, 23);
            this.btnSignIn.TabIndex = 18;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.DoSignIn);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignOut.Enabled = false;
            this.btnSignOut.Location = new System.Drawing.Point(613, 62);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(117, 23);
            this.btnSignOut.TabIndex = 19;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.DoSignOut);
            // 
            // comboQuery
            // 
            this.comboQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuery.Enabled = false;
            this.comboQuery.FormattingEnabled = true;
            this.comboQuery.Location = new System.Drawing.Point(57, 6);
            this.comboQuery.Name = "comboQuery";
            this.comboQuery.Size = new System.Drawing.Size(195, 21);
            this.comboQuery.TabIndex = 15;
            // 
            // queryResults
            // 
            this.queryResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.queryResults.Location = new System.Drawing.Point(6, 33);
            this.queryResults.Name = "queryResults";
            this.queryResults.Size = new System.Drawing.Size(691, 351);
            this.queryResults.TabIndex = 0;
            // 
            // schemaInfoPanel1
            // 
            this.schemaInfoPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.schemaInfoPanel1.Location = new System.Drawing.Point(6, 6);
            this.schemaInfoPanel1.Name = "schemaInfoPanel1";
            this.schemaInfoPanel1.Size = new System.Drawing.Size(698, 187);
            this.schemaInfoPanel1.TabIndex = 0;
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 572);
            this.Controls.Add(this.btnRefreshSchemas);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetSchemas);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDebugLocation);
            this.Controls.Add(this.chkWriteDebug);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrl);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "SampleFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.SampleFormLocation;
            this.Name = "SampleForm";
            this.Text = "SampleForm";
            this.Load += new System.EventHandler(this.DoFormLoaded);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoFormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabQueryResult.ResumeLayout(false);
            this.tabQueryResult.PerformLayout();
            this.tabSchemas.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
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
    }
}
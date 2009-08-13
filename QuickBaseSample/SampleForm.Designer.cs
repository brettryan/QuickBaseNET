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
            this.lblDBID = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblQueryNum = new System.Windows.Forms.Label();
            this.txtDebugLocation = new System.Windows.Forms.TextBox();
            this.chkWriteDebug = new System.Windows.Forms.CheckBox();
            this.txtQueryNum = new System.Windows.Forms.TextBox();
            this.txtDBID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetSchemas
            // 
            this.btnGetSchemas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetSchemas.Location = new System.Drawing.Point(628, 116);
            this.btnGetSchemas.Name = "btnGetSchemas";
            this.btnGetSchemas.Size = new System.Drawing.Size(117, 23);
            this.btnGetSchemas.TabIndex = 1;
            this.btnGetSchemas.Text = "Get Schemas";
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
            this.txtOutput.BackColor = System.Drawing.Color.MidnightBlue;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtOutput.Location = new System.Drawing.Point(15, 168);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(730, 413);
            this.txtOutput.TabIndex = 9;
            this.txtOutput.Text = "";
            // 
            // lblDBID
            // 
            this.lblDBID.AutoSize = true;
            this.lblDBID.Location = new System.Drawing.Point(12, 93);
            this.lblDBID.Name = "lblDBID";
            this.lblDBID.Size = new System.Drawing.Size(36, 13);
            this.lblDBID.TabIndex = 10;
            this.lblDBID.Text = "DB ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(547, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Run Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DoPerformQuery);
            // 
            // lblQueryNum
            // 
            this.lblQueryNum.AutoSize = true;
            this.lblQueryNum.Location = new System.Drawing.Point(13, 119);
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
            this.txtDebugLocation.Location = new System.Drawing.Point(204, 142);
            this.txtDebugLocation.Name = "txtDebugLocation";
            this.txtDebugLocation.Size = new System.Drawing.Size(541, 20);
            this.txtDebugLocation.TabIndex = 16;
            this.txtDebugLocation.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.DebuggingLocation;
            this.txtDebugLocation.Click += new System.EventHandler(this.DoLocationClicked);
            // 
            // chkWriteDebug
            // 
            this.chkWriteDebug.AutoSize = true;
            this.chkWriteDebug.Checked = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.DebuggingEnabled;
            this.chkWriteDebug.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "DebuggingEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkWriteDebug.Location = new System.Drawing.Point(12, 144);
            this.chkWriteDebug.Name = "chkWriteDebug";
            this.chkWriteDebug.Size = new System.Drawing.Size(186, 17);
            this.chkWriteDebug.TabIndex = 15;
            this.chkWriteDebug.Text = "Write Debugging Files to Location";
            this.chkWriteDebug.UseVisualStyleBackColor = true;
            // 
            // txtQueryNum
            // 
            this.txtQueryNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueryNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBaseQueryNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtQueryNum.Location = new System.Drawing.Point(78, 116);
            this.txtQueryNum.Name = "txtQueryNum";
            this.txtQueryNum.Size = new System.Drawing.Size(463, 20);
            this.txtQueryNum.TabIndex = 14;
            this.txtQueryNum.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBaseQueryNumber;
            // 
            // txtDBID
            // 
            this.txtDBID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBID.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBaseDBID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDBID.Location = new System.Drawing.Point(78, 90);
            this.txtDBID.Name = "txtDBID";
            this.txtDBID.Size = new System.Drawing.Size(667, 20);
            this.txtDBID.TabIndex = 11;
            this.txtDBID.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBaseDBID;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JohnSands.QuickBase.Sample.Properties.Settings.Default, "QuickBasePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPassword.Location = new System.Drawing.Point(78, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(667, 20);
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
            this.txtUserName.Size = new System.Drawing.Size(667, 20);
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
            this.txtUrl.Size = new System.Drawing.Size(667, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = global::JohnSands.QuickBase.Sample.Properties.Settings.Default.QuickBaseUrl;
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 593);
            this.Controls.Add(this.txtDebugLocation);
            this.Controls.Add(this.chkWriteDebug);
            this.Controls.Add(this.txtQueryNum);
            this.Controls.Add(this.lblQueryNum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDBID);
            this.Controls.Add(this.lblDBID);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnGetSchemas);
            this.Controls.Add(this.txtUrl);
            this.Name = "SampleForm";
            this.Text = "SampleForm";
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
        private System.Windows.Forms.TextBox txtDBID;
        private System.Windows.Forms.Label lblDBID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblQueryNum;
        private System.Windows.Forms.TextBox txtQueryNum;
        private System.Windows.Forms.CheckBox chkWriteDebug;
        private System.Windows.Forms.TextBox txtDebugLocation;
    }
}
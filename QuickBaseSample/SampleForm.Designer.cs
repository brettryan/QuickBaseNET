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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGetSchemas = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.txtDBID = new System.Windows.Forms.TextBox();
            this.lblDBID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(78, 12);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(324, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "https://amgreetings.quickbase.com/db/";
            // 
            // btnGetSchemas
            // 
            this.btnGetSchemas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetSchemas.Location = new System.Drawing.Point(285, 116);
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
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(78, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(324, 20);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.Text = "brett.ryan@johnsands.com.au";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(78, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(324, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "Moropima01";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(15, 145);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(387, 219);
            this.txtOutput.TabIndex = 9;
            this.txtOutput.Text = "";
            // 
            // txtDBID
            // 
            this.txtDBID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBID.Location = new System.Drawing.Point(78, 90);
            this.txtDBID.Name = "txtDBID";
            this.txtDBID.Size = new System.Drawing.Size(324, 20);
            this.txtDBID.TabIndex = 11;
            this.txtDBID.Text = "begy9tmr3";
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
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 376);
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
    }
}
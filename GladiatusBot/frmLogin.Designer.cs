namespace GladiatusBot
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.inputCountry = new MetroFramework.Controls.MetroComboBox();
            this.inputProvince = new MetroFramework.Controls.MetroTextBox();
            this.inputUsername = new MetroFramework.Controls.MetroTextBox();
            this.inputPassword = new MetroFramework.Controls.MetroTextBox();
            this.inputRememberMe = new MetroFramework.Controls.MetroCheckBox();
            this.buttonLogin = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 70);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(56, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Country";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 101);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(59, 19);
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "Province";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 130);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Username";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 158);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(63, 19);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "Password";
            // 
            // inputCountry
            // 
            this.inputCountry.FormattingEnabled = true;
            this.inputCountry.ItemHeight = 23;
            this.inputCountry.Location = new System.Drawing.Point(97, 63);
            this.inputCountry.Name = "inputCountry";
            this.inputCountry.Size = new System.Drawing.Size(158, 29);
            this.inputCountry.TabIndex = 14;
            this.inputCountry.UseSelectable = true;
            // 
            // inputProvince
            // 
            this.inputProvince.Lines = new string[0];
            this.inputProvince.Location = new System.Drawing.Point(97, 99);
            this.inputProvince.MaxLength = 32767;
            this.inputProvince.Name = "inputProvince";
            this.inputProvince.PasswordChar = '\0';
            this.inputProvince.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputProvince.SelectedText = "";
            this.inputProvince.Size = new System.Drawing.Size(158, 23);
            this.inputProvince.TabIndex = 15;
            this.inputProvince.UseSelectable = true;
            // 
            // inputUsername
            // 
            this.inputUsername.Lines = new string[0];
            this.inputUsername.Location = new System.Drawing.Point(97, 128);
            this.inputUsername.MaxLength = 32767;
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.PasswordChar = '\0';
            this.inputUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputUsername.SelectedText = "";
            this.inputUsername.Size = new System.Drawing.Size(158, 23);
            this.inputUsername.TabIndex = 16;
            this.inputUsername.UseSelectable = true;
            // 
            // inputPassword
            // 
            this.inputPassword.Lines = new string[0];
            this.inputPassword.Location = new System.Drawing.Point(97, 157);
            this.inputPassword.MaxLength = 32767;
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.PasswordChar = '\0';
            this.inputPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputPassword.SelectedText = "";
            this.inputPassword.Size = new System.Drawing.Size(158, 23);
            this.inputPassword.TabIndex = 17;
            this.inputPassword.UseSelectable = true;
            // 
            // inputRememberMe
            // 
            this.inputRememberMe.AutoSize = true;
            this.inputRememberMe.Location = new System.Drawing.Point(23, 194);
            this.inputRememberMe.Name = "inputRememberMe";
            this.inputRememberMe.Size = new System.Drawing.Size(101, 15);
            this.inputRememberMe.TabIndex = 18;
            this.inputRememberMe.Text = "Remember Me";
            this.inputRememberMe.UseSelectable = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(137, 189);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(118, 23);
            this.buttonLogin.TabIndex = 19;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseSelectable = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 237);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.inputRememberMe);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.inputUsername);
            this.Controls.Add(this.inputProvince);
            this.Controls.Add(this.inputCountry);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox inputCountry;
        private MetroFramework.Controls.MetroTextBox inputProvince;
        private MetroFramework.Controls.MetroTextBox inputUsername;
        private MetroFramework.Controls.MetroTextBox inputPassword;
        private MetroFramework.Controls.MetroCheckBox inputRememberMe;
        private MetroFramework.Controls.MetroButton buttonLogin;


    }
}


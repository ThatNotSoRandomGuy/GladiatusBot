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
            this.inputCountry = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputProvince = new System.Windows.Forms.TextBox();
            this.inputUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.inputRememberMe = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // inputCountry
            // 
            this.inputCountry.FormattingEnabled = true;
            this.inputCountry.Location = new System.Drawing.Point(73, 12);
            this.inputCountry.Name = "inputCountry";
            this.inputCountry.Size = new System.Drawing.Size(150, 21);
            this.inputCountry.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Country";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Province";
            // 
            // inputProvince
            // 
            this.inputProvince.Location = new System.Drawing.Point(73, 39);
            this.inputProvince.Name = "inputProvince";
            this.inputProvince.Size = new System.Drawing.Size(150, 20);
            this.inputProvince.TabIndex = 3;
            // 
            // inputUsername
            // 
            this.inputUsername.Location = new System.Drawing.Point(73, 65);
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.Size = new System.Drawing.Size(150, 20);
            this.inputUsername.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username";
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(73, 91);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.PasswordChar = '*';
            this.inputPassword.Size = new System.Drawing.Size(150, 20);
            this.inputPassword.TabIndex = 7;
            this.inputPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(115, 117);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(108, 23);
            this.buttonLogin.TabIndex = 8;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // inputRememberMe
            // 
            this.inputRememberMe.AutoSize = true;
            this.inputRememberMe.Location = new System.Drawing.Point(15, 121);
            this.inputRememberMe.Name = "inputRememberMe";
            this.inputRememberMe.Size = new System.Drawing.Size(94, 17);
            this.inputRememberMe.TabIndex = 9;
            this.inputRememberMe.Text = "Remember me";
            this.inputRememberMe.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 153);
            this.Controls.Add(this.inputRememberMe);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputProvince);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputCountry);
            this.Name = "frmLogin";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox inputCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputProvince;
        private System.Windows.Forms.TextBox inputUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.CheckBox inputRememberMe;

    }
}


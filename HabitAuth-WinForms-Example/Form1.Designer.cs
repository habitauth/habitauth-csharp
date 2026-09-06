namespace HabitAuthExample
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLicenseOnly;
        private System.Windows.Forms.Button btnResetHwid;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblHwid;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLicenseOnly = new System.Windows.Forms.Button();
            this.btnResetHwid = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblHwid = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.ClientSize = new System.Drawing.Size(420, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habit Auth - Authentication Client";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 37);
            this.lblTitle.Text = "Habit Auth";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblSubtitle.Location = new System.Drawing.Point(32, 65);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(250, 20);
            this.lblSubtitle.Text = "Hardware-Locked License Client";

            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.lblUsername.Location = new System.Drawing.Point(32, 105);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 20);
            this.lblUsername.Text = "Username";

            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.Location = new System.Drawing.Point(35, 130);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(350, 30);

            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.lblPassword.Location = new System.Drawing.Point(32, 175);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 20);
            this.lblPassword.Text = "Password";

            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(35, 200);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(350, 30);

            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLicense.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.lblLicense.Location = new System.Drawing.Point(32, 245);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(130, 20);
            this.lblLicense.Text = "License Key (Token)";

            this.txtLicense.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.txtLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicense.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLicense.ForeColor = System.Drawing.Color.White;
            this.txtLicense.Location = new System.Drawing.Point(35, 270);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(350, 30);

            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(35, 315);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(170, 38);
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(215, 315);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(170, 38);
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnLicenseOnly.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnLicenseOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLicenseOnly.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLicenseOnly.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnLicenseOnly.Location = new System.Drawing.Point(35, 362);
            this.btnLicenseOnly.Name = "btnLicenseOnly";
            this.btnLicenseOnly.Size = new System.Drawing.Size(170, 34);
            this.btnLicenseOnly.Text = "Key Only Login";
            this.btnLicenseOnly.UseVisualStyleBackColor = false;
            this.btnLicenseOnly.Click += new System.EventHandler(this.btnLicenseOnly_Click);

            this.btnResetHwid.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnResetHwid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetHwid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnResetHwid.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnResetHwid.Location = new System.Drawing.Point(215, 362);
            this.btnResetHwid.Name = "btnResetHwid";
            this.btnResetHwid.Size = new System.Drawing.Size(170, 34);
            this.btnResetHwid.Text = "Reset HWID";
            this.btnResetHwid.UseVisualStyleBackColor = false;
            this.btnResetHwid.Click += new System.EventHandler(this.btnResetHwid_Click);

            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblStatus.Location = new System.Drawing.Point(35, 410);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(350, 45);
            this.lblStatus.Text = "Ready.";

            this.lblHwid.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblHwid.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblHwid.Location = new System.Drawing.Point(35, 470);
            this.lblHwid.Name = "lblHwid";
            this.lblHwid.Size = new System.Drawing.Size(350, 30);
            this.lblHwid.Text = "HWID: Initializing...";

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLicenseOnly);
            this.Controls.Add(this.btnResetHwid);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblHwid);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

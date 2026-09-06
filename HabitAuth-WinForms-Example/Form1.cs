using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using HabitAuthSDK;

namespace HabitAuthExample
{
    public partial class Form1 : Form
    {
        // Replace with your Application credentials from habitauth.com
        private const string AppId = "app_c0049143710d4e5c";
        private const string AppSecret = "sec_0000000000000000";
        private const string Version = "1.0.0";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Connecting to Habit Auth...";
            lblStatus.ForeColor = Color.DarkGray;
            lblHwid.Text = "HWID: " + HabitAuth.GetHardwareId();

            HabitAuth.Setup(AppId, AppSecret, Version);
            var result = await HabitAuth.InitializeAsync();

            if (result.Success)
            {
                lblStatus.Text = "Ready. Connected to Habit Auth.";
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
            }
            else
            {
                lblStatus.Text = "Initialization failed: " + result.Message;
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Please enter both username and password.";
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                return;
            }

            SetLoading(true, "Authenticating...");
            var result = await HabitAuth.LoginAsync(username, password);
            SetLoading(false);

            if (result.Success)
            {
                lblStatus.Text = "Login successful!";
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);

                this.Hide();
                Main mainForm = new Main();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                lblStatus.Text = result.Message;
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string key = txtLicense.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(key))
            {
                lblStatus.Text = "Please fill username, password, and license key.";
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                return;
            }

            SetLoading(true, "Creating account...");
            var result = await HabitAuth.RegisterAsync(username, password, key);
            SetLoading(false);

            if (result.Success)
            {
                lblStatus.Text = "Account registered successfully! You can now log in.";
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
            }
            else
            {
                lblStatus.Text = result.Message;
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        private async void btnLicenseOnly_Click(object sender, EventArgs e)
        {
            string key = txtLicense.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                lblStatus.Text = "Please enter your license key.";
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                return;
            }

            SetLoading(true, "Verifying license key...");
            var result = await HabitAuth.LicenseLoginAsync(key);
            SetLoading(false);

            if (result.Success)
            {
                lblStatus.Text = "License verified!";
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);

                this.Hide();
                Main mainForm = new Main();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                lblStatus.Text = result.Message;
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        private async void btnResetHwid_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Enter username and password to reset HWID.";
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                return;
            }

            SetLoading(true, "Resetting HWID...");
            var result = await HabitAuth.ResetHwidAsync(username, password);
            SetLoading(false);

            if (result.Success)
            {
                lblStatus.Text = "HWID reset successfully! You can now log in.";
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
            }
            else
            {
                lblStatus.Text = result.Message;
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        private void SetLoading(bool loading, string text = "")
        {
            btnLogin.Enabled = !loading;
            btnRegister.Enabled = !loading;
            btnLicenseOnly.Enabled = !loading;
            btnResetHwid.Enabled = !loading;
            if (loading)
            {
                lblStatus.Text = text;
                lblStatus.ForeColor = Color.FromArgb(99, 102, 241);
            }
        }
    }
}

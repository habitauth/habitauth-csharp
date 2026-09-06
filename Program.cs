// Form1.cs - Windows Forms (.NET Framework 4.5 - 4.8 / .NET 6 - 10)
using System;
using System.Windows.Forms;
using HabitAuth;

namespace HabitAuthWinForms
{
    public partial class Form1 : Form
    {
        // 1. Initialize HabitAuth with credentials from your dashboard
        // Supports .NET Framework 4.5, 4.6, 4.7, 4.8 and modern .NET without external NuGet packages!
        public static api HabitAuthApp = new api(
            name: "TARGET_APP_NAME",
            ownerid: "TARGET_APP_ID",
            secret: "TARGET_APP_SECRET",
            version: "1.0.0",
            publicKey: "TARGET_PUBLIC_KEY" // Optional Ed25519 public key
        );

        public Form1()
        {
            InitializeComponent();
        }

        // 2. Cryptographic session handshake on Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            HabitAuthApp.init();

            if (!HabitAuthApp.response.success)
            {
                MessageBox.Show("Initialization Failed: " + HabitAuthApp.response.message, "HabitAuth", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        // 3. Login Button Click - Authenticate with Username & Password TextBoxes
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (HabitAuthApp.login(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Login Successful!\nWelcome: " + HabitAuthApp.user_data.username + "\nExpires: " + HabitAuthApp.user_data.expires_at, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Start automatic background heartbeat telemetry (monitors bans & remote kills)
                HabitAuthApp.start_heartbeat(30);

                // Open your Main Dashboard Form:
                // MainDashboard main = new MainDashboard(); // (Replace MainDashboard with your Form name)
                // main.Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed: " + HabitAuthApp.response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Register Button Click - Create Account with Username, Password & License TextBoxes
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (HabitAuthApp.register(txtUsername.Text, txtPassword.Text, txtLicense.Text))
            {
                MessageBox.Show("Registration Successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Registration Failed: " + HabitAuthApp.response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. License Only Button Click - 1-Key Authentication with License TextBox
        private void btnLicenseOnly_Click(object sender, EventArgs e)
        {
            if (HabitAuthApp.license(txtLicense.Text))
            {
                MessageBox.Show("License Validated!\nExpires: " + HabitAuthApp.user_data.expires_at, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabitAuthApp.start_heartbeat(30);

                // Open your Main Dashboard Form:
                // MainDashboard main = new MainDashboard(); // (Replace MainDashboard with your Form name)
                // main.Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("License Invalid: " + HabitAuthApp.response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
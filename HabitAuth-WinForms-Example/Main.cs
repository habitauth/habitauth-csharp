using System;
using System.Drawing;
using System.Windows.Forms;
using HabitAuthSDK;

namespace HabitAuthExample
{
    public partial class Main : Form
    {
        private Timer _heartbeatTimer;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome back, " + HabitAuth.User.Username + "!";
            lblSubscription.Text = "Plan: " + HabitAuth.User.Subscription.ToUpper();

            if (HabitAuth.User.ExpiresAt == 0)
            {
                lblExpiry.Text = "Expires: Lifetime License";
                lblExpiry.ForeColor = Color.FromArgb(16, 185, 129);
            }
            else
            {
                DateTime dt = DateTimeOffset.FromUnixTimeSeconds(HabitAuth.User.ExpiresAt).LocalDateTime;
                lblExpiry.Text = "Expires: " + dt.ToString("f");
            }

            lblHwid.Text = "Hardware ID: " + HabitAuth.User.Hwid;
            lblAppVersion.Text = "App Version: " + HabitAuth.App.Version;

            _heartbeatTimer = new Timer();
            _heartbeatTimer.Interval = 60000;
            _heartbeatTimer.Tick += async (s, ev) =>
            {
                bool alive = await HabitAuth.HeartbeatAsync();
                if (!alive)
                {
                    _heartbeatTimer.Stop();
                    MessageBox.Show("Your session was terminated or expired by administrator.", "Session Closed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            };
            _heartbeatTimer.Start();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Protected feature launched successfully! Session token is valid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _heartbeatTimer?.Stop();
            this.Close();
        }
    }
}

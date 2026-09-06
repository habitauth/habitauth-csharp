namespace HabitAuthExample
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblSubscription;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.Label lblHwid;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnLogout;

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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblSubscription = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.lblHwid = new System.Windows.Forms.Label();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habit Auth - Main Dashboard";
            this.Load += new System.EventHandler(this.Main_Load);

            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(30, 25);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(260, 37);
            this.lblHeader.Text = "Habit Auth Dashboard";

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblWelcome.Location = new System.Drawing.Point(32, 70);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(150, 25);
            this.lblWelcome.Text = "Welcome back!";

            this.pnlCard.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.pnlCard.Controls.Add(this.lblSubscription);
            this.pnlCard.Controls.Add(this.lblExpiry);
            this.pnlCard.Controls.Add(this.lblHwid);
            this.pnlCard.Controls.Add(this.lblAppVersion);
            this.pnlCard.Location = new System.Drawing.Point(35, 110);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(490, 180);

            this.lblSubscription.AutoSize = true;
            this.lblSubscription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubscription.ForeColor = System.Drawing.Color.White;
            this.lblSubscription.Location = new System.Drawing.Point(20, 20);
            this.lblSubscription.Name = "lblSubscription";
            this.lblSubscription.Size = new System.Drawing.Size(140, 23);
            this.lblSubscription.Text = "Plan: Developer";

            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExpiry.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.lblExpiry.Location = new System.Drawing.Point(20, 55);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(120, 20);
            this.lblExpiry.Text = "Expires: Lifetime";

            this.lblHwid.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHwid.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblHwid.Location = new System.Drawing.Point(20, 90);
            this.lblHwid.Name = "lblHwid";
            this.lblHwid.Size = new System.Drawing.Size(450, 35);
            this.lblHwid.Text = "Hardware ID: ...";

            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAppVersion.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblAppVersion.Location = new System.Drawing.Point(20, 135);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(125, 20);
            this.lblAppVersion.Text = "App Version: 1.0.0";

            this.btnLaunch.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLaunch.ForeColor = System.Drawing.Color.White;
            this.btnLaunch.Location = new System.Drawing.Point(35, 320);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(235, 45);
            this.btnLaunch.Text = "Launch Protected App";
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);

            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(290, 320);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(235, 45);
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnLogout);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

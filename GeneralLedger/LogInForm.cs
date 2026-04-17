using GeneralLedger.Core.Domain;
using GeneralLedger.Persistence.Services;
using GeneralLedger.Tier.BAL;
using GeneralLedger.Tier.BO;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLedger
{
    public partial class LogInForm : MetroForm
    {
        public UserServices UserServices { get; set; }
        public RoleServices RoleServices { get; set; }
        public LogInForm()
        {
            InitializeComponent();
            UserServices = new UserServices();
            RoleServices = new RoleServices();
            SetVersionInfo();
        }

        private void SetVersionInfo()
        {
            string versionText = "";

            // Try to get ClickOnce publish version first
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment deployment = ApplicationDeployment.CurrentDeployment;
                Version publishVersion = deployment.CurrentVersion;
                DateTime buildDate = DateTime.Now;
                versionText = $"Version {publishVersion.Major}.{publishVersion.Minor}.{publishVersion.Build}.{publishVersion.Revision} - Published: {buildDate:yyyy-MM-dd}";
            }
            else
            {
                // Fallback to assembly version
                Assembly assembly = Assembly.GetExecutingAssembly();
                Version version = assembly.GetName().Version;
                DateTime buildDate = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
                versionText = $"Version {version.Major}.{version.Minor}.{version.Build}.{version.Revision} - Build Date: {buildDate:yyyy-MM-dd HH:mm}";
            }

            this.metroLabel3.Text = versionText;
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            var user = UserServices.LoginUsername(this.txtUsername.Text);
            if (user == null)
            {
                this.txtError.Text = "* Invalid username or password";
                //MessageBox.Show("Invalid username");
                return;
            }

            if (user.IsResetPassword.HasValue)
            {
                if ((bool)user.IsResetPassword)
                {
                    ResetPassword reset = new ResetPassword();
                    reset.LogInForm = this;
                    reset.User = user;
                    reset.Show();
                    this.Hide();
                }
                else
                {
                    var loginUser = UserServices.LoginPassword(this.txtPassword.Text, this.txtUsername.Text);


                    if (loginUser != null)
                    {
                        UserProfile.UserUserProfile = loginUser;
                        UserProfile.UserProfileRoles = RoleServices.GetRolesByUser(ur => ur.UserId == loginUser.Id).ToList();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.txtError.Text = "* Invalid username or password";
                    }
                }
            }
          

        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.txtError.Text = String.Empty;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtError.Text = String.Empty;
        }

        private void LogInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

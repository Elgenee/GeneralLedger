using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.BAL;
using System.Globalization;
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;

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

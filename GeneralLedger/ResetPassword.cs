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
    public partial class ResetPassword : MetroForm
    {
        public User User { get; set; }
        public UserServices UserServices { get; set; }

        public LogInForm LogInForm { get; set; }
        public ResetPassword()
        {
            InitializeComponent();
            UserServices = new UserServices();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPassword.Text) || string.IsNullOrEmpty(this.txtConfirmPassword.Text))
            {
                this.txtError.Text = "* Password doesn't match";
                return;
            }

            if (this.txtPassword.Text.Equals(this.txtConfirmPassword.Text))
            {
                if (UserServices.ResetNewPassword(User.Id, this.txtPassword.Text, User.Username))
                {
                    MessageBox.Show("Reset successfully...");
                    this.Close();
                    LogInForm.Show();

                }


            }
            else
            {
                this.txtError.Text = "* Password doesn't match";
            }
        }

        private void ResetPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

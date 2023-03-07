using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.BAL;
using System.Globalization;
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.UserControls
{
    public partial class frmUser : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public User User { get; set; }
        public UserServices UserServices { get; set; }
        public RoleServices RoleServices { get; set; }
        public int ID { get; set; }
        public List<Role> ListOfRoles { get; set; }
        public int IndexGrid { get; set; }

        public frmUser()
        {
            InitializeComponent();
            UserServices = new UserServices();
            RoleServices = new RoleServices();
            ListOfRoles = new List<Role>();
            User = new User();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                string TransType = (this.ID == 0) ? "insert" : "update";

                if (TransType.Equals("insert"))
                {
                    User = new User {
                         Id = ID,
                         Name = this.txtName.Text,
                         Username = this.txtUsername.Text,
                         IsResetPassword = true
                    };

                    User = UserServices.Add(User, ListOfRoles);

                    if (User != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }
                else
                {
                    User.Id = this.ID;
                    User.Name = this.txtName.Text;
                    User.Username = this.txtUsername.Text;
                    User = UserServices.Update(User, ListOfRoles);


                    if (User != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }

                this.ID = User.Id;
                this.txtUserID.Text = this.ID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            SearchRole sr = new SearchRole();
            sr.BringToFront();
            sr.TopMost = true;
            DialogResult res = sr.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                var role = new Role { 
                     Id = sr.Role.Id,
                     Name = sr.Role.Name
                };

                if (ListOfRoles.Exists(l => l.Id == role.Id))
                    return;

                ListOfRoles.Add(role);

                if (ListOfRoles.Count > 0 )
                {
                    this.dgRole.Rows.Clear();
                    this.dgRole.Refresh();

                    this.dgRole.ColumnCount = 2;
                    this.dgRole.RowCount = this.ListOfRoles.Count;

                    //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgRole.Columns[0].Name = "ID";
                    //this.dgRole.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgRole.Columns[1].Name = "RoleName";
                    this.dgRole.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          
                    this.dgRole.Columns[0].ReadOnly = true;
                    this.dgRole.Columns[1].ReadOnly = true;


                    for (int i = 0; i < ListOfRoles.Count; i++)
                    {
                        this.dgRole.Rows[i].Cells[0].Value = ListOfRoles[i].Id;
                        this.dgRole.Rows[i].Cells[1].Value = ListOfRoles[i].Name;
                    }

                    setRowNumber(this.dgRole);
                }
            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListOfRoles.Count > 0)
                {
                    if (this.dgRole.CurrentRow is null) 
                    {
                        MessageBox.Show("Please select item");
                        return;
                    }
                     
                    ListOfRoles.RemoveAt(this.dgRole.CurrentRow.Index);
                    this.dgRole.Rows.Clear();
                    this.dgRole.Refresh();

                    if (this.ListOfRoles.Count == 0)
                    {
                        return;
                    }

                    this.dgRole.ColumnCount = 2;
                    this.dgRole.RowCount = this.ListOfRoles.Count;

                    this.dgRole.Columns[0].Name = "ID";
                    //this.dgRole.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgRole.Columns[1].Name = "RoleName";
                    this.dgRole.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    for (int i = 0; i < ListOfRoles.Count; i++)
                    {
                        this.dgRole.Rows[i].Cells[0].Value = ListOfRoles[i].Id;
                        this.dgRole.Rows[i].Cells[1].Value = ListOfRoles[i].Name;
                    }
                    setRowNumber(this.dgRole);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.IndexGrid = e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            frmSearchUser su = new frmSearchUser();
            su.BringToFront();
            su.TopMost = true;
            DialogResult res = su.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                this.ID = su.User.Id;
                this.txtUserID.Text = su.User.Id.ToString();
                this.txtName.Text = su.User.Name;
                this.txtUsername.Text = su.User.Username;
                this.ListOfRoles = RoleServices.GetRolesByUser(ur => ur.UserId == su.User.Id).ToList();

                if (ListOfRoles.Count > 0 )
                {
                    this.dgRole.ColumnCount = 2;
                    this.dgRole.RowCount = this.ListOfRoles.Count;

                    this.dgRole.Columns[0].Name = "ID";
                    //this.dgRole.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgRole.Columns[1].Name = "RoleName";
                    this.dgRole.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    for (int i = 0; i < ListOfRoles.Count; i++)
                    {
                        this.dgRole.Rows[i].Cells[0].Value = ListOfRoles[i].Id;
                        this.dgRole.Rows[i].Cells[1].Value = ListOfRoles[i].Name;
                    }
                    setRowNumber(this.dgRole);
                }
                else
                {
                    this.dgRole.Rows.Clear();
                    this.dgRole.Refresh();
                    this.ListOfRoles.Clear();
                }
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string TransType = (this.ID > 0) ? "delete" : String.Empty;

                if (TransType.Equals("delete"))
                {
                    User = new User
                    {
                        Id = ID,
                        Name = this.txtName.Text,
                        Username = this.txtUsername.Text,
                        IsResetPassword = true
                    };

                    UserServices.Remove(User, ListOfRoles);

                    if (User != null)
                    {
                        this.ID = 0;
                        this.txtUserID.Text = String.Empty;
                        this.txtName.Text = String.Empty;
                        this.txtUsername.Text = String.Empty;
                        this.dgRole.Rows.Clear();
                        this.dgRole.Refresh();
                        this.ListOfRoles = new List<Role>();
                        MessageBox.Show("Successfully deleted");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.ID = 0;
            this.txtUserID.Text = String.Empty;
            this.txtName.Text = String.Empty;
            this.txtUsername.Text = String.Empty;
            this.dgRole.Rows.Clear();
            this.dgRole.Refresh();
            this.ListOfRoles = new List<Role>();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (UserServices.ResetPassword(this.ID))
            {
                MessageBox.Show("Successfully reset");
            }
        }
    }
}

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
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.UserControls
{
    public partial class frmSearchUser : MetroForm
    {
        public User User { get; set; }

        public UserServices UserServices { get; set; }

        public int Index { get; set; }

        public frmSearchUser()
        {
            InitializeComponent();
            UserServices = new UserServices();
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<User> userResult;
                if (string.IsNullOrEmpty(this.txtCriteria.Text))
                    userResult = UserServices.GetAll();
                else
                    userResult = UserServices.GetUserWithRoles(this.txtCriteria.Text).ToList();

                if ((userResult != null) && userResult.Count > 0)
                {
                    this.dgSearchUser.RowCount = userResult.Count;
                    for (int i = 0; i < userResult.Count; i++)
                    {
                        this.dgSearchUser.Rows[i].Cells["ID"].Value = ReferenceEquals(userResult[i].Id, DBNull.Value) ? 0 : userResult[i].Id;
                        this.dgSearchUser.Rows[i].Cells["UName"].Value = userResult[i].Name;
                        this.dgSearchUser.Rows[i].Cells["Username"].Value = userResult[i].Username;
      
                    }
                    setRowNumber(this.dgSearchUser);

                }
                else
                {
                    this.dgSearchUser.Rows.Clear();
                    this.dgSearchUser.Refresh();
                    MessageBox.Show("No Result");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Index = this.dgSearchUser.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.User = new User {
                     Id = ReferenceEquals(this.dgSearchUser.Rows[this.Index].Cells["ID"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchUser.Rows[this.Index].Cells["ID"].Value),
                     Name = ReferenceEquals(this.dgSearchUser.Rows[this.Index].Cells["UName"].Value, DBNull.Value) ? string.Empty : Convert.ToString(this.dgSearchUser.Rows[this.Index].Cells["UName"].Value),
                     Username = ReferenceEquals(this.dgSearchUser.Rows[this.Index].Cells["Username"].Value, DBNull.Value) ? string.Empty : Convert.ToString(this.dgSearchUser.Rows[this.Index].Cells["Username"].Value)
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select item");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}

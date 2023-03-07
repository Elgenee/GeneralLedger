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
    public partial class SearchRole : MetroForm
    {
        public Role Role { get; set; }
        public RoleServices RoleServices { get; set; }
        public int Index { get; set; }
        public SearchRole()
        {
            InitializeComponent();
            RoleServices = new RoleServices();
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
                List<Role> rolesResult;
                if (string.IsNullOrEmpty(this.txtCriteria.Text))
                    rolesResult = RoleServices.GetAll();
                else
                    rolesResult = RoleServices.GetAll().Where(r => r.Name.Contains(this.txtCriteria.Text)).ToList();

                if ((rolesResult != null) && rolesResult.Count > 0)
                {
                    this.dgSearchRole.RowCount = rolesResult.Count;

                    for (int i = 0; i < rolesResult.Count; i++)
                    {
                        this.dgSearchRole.Rows[i].Cells["ID"].Value = ReferenceEquals(rolesResult[i].Id, DBNull.Value) ? 0 : rolesResult[i].Id;
                        this.dgSearchRole.Rows[i].Cells["RoleName"].Value =  rolesResult[i].Name;
                    }
                    setRowNumber(this.dgSearchRole);
                }
                else
                {
                    this.dgSearchRole.Rows.Clear();
                    this.dgSearchRole.Refresh();
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
                this.Index = this.dgSearchRole.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.Role = new Role
                    {
                        Id = ReferenceEquals(this.dgSearchRole.Rows[this.Index].Cells["ID"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchRole.Rows[this.Index].Cells["ID"].Value),
                        Name = ReferenceEquals(this.dgSearchRole.Rows[this.Index].Cells["RoleName"].Value, DBNull.Value) ? string.Empty : Convert.ToString(this.dgSearchRole.Rows[this.Index].Cells["RoleName"].Value)

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

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
using GeneralLedger.Tier.BAL;
using GeneralLedger.Tier.BO;
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.UserControls
{
    public partial class SearchAgent : MetroForm
    {

        public Agent Agent { get; set; }
        public AgentServices AgentServices { get; set; }
        public int Index { get; set; }
        public SearchAgent()
        {
            InitializeComponent();
            AgentServices = new AgentServices();
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
                List<Agent> agentsList;
                if (string.IsNullOrEmpty(this.txtCriteria.Text))
                {
                    agentsList = AgentServices.GetAgents();
                }
                else
                {
                    agentsList = AgentServices.GetAgents().Where(a => a.Name.ToLower().Contains(this.txtCriteria.Text.ToLower())
                    || a.Address.ToLower().Contains(this.txtCriteria.Text.ToLower())
                    || a.Contact.ToLower().Contains(this.txtCriteria.Text.ToLower())).ToList();
                }


                if ((agentsList != null) && agentsList.Count > 0)
                {
                    //this.dgSearchCustomer.ColumnCount = 9;
                    this.dgSearchAgent.RowCount = agentsList.Count;

                    for (int i = 0; i < agentsList.Count; i++)
                    {
                        this.dgSearchAgent.Rows[i].Cells["ID"].Value = agentsList[i].Id;
                        this.dgSearchAgent.Rows[i].Cells["AgentName"].Value = agentsList[i].Name;
                        this.dgSearchAgent.Rows[i].Cells["StartingDebit"].Value = agentsList[i].StartingDebit;
                        this.dgSearchAgent.Rows[i].Cells["Address"].Value = agentsList[i].Address;
                        this.dgSearchAgent.Rows[i].Cells["Contact"].Value = agentsList[i].Contact;
                    }
                    setRowNumber(this.dgSearchAgent);
                }
                else
                {

                    this.dgSearchAgent.Rows.Clear();
                    this.dgSearchAgent.Refresh();
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
                this.Index = this.dgSearchAgent.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.Agent = new Agent
                    {
                        Id = Int32.Parse(this.dgSearchAgent.Rows[this.Index].Cells["ID"].Value.ToString()),
                        Name = this.dgSearchAgent.Rows[this.Index].Cells["AgentName"].Value.ToString(),
                        StartingDebit = decimal.Parse(this.dgSearchAgent.Rows[this.Index].Cells["StartingDebit"].Value.ToString()),
                        Address = this.dgSearchAgent.Rows[this.Index].Cells["Address"].Value.ToString(),
                        Contact = this.dgSearchAgent.Rows[this.Index].Cells["Contact"].Value.ToString()
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

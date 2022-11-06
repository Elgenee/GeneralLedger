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
    public partial class frmAgent : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int ID { get; set; } = 0;

        public Agent Agent { get; set; }
        public AgentServices AgentServices { get; set; }
        public frmAgent()
        {
            InitializeComponent();
            AgentServices = new AgentServices();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser;
                decimal decimalParser;
                string TransType = (this.ID == 0) ? "insert" : "update";

                Agent = new Agent
                {
                    Id = this.ID,
                    Name = this.txtAgentName.Text,
                    StartingDebit = decimal.TryParse(this.txtStartingDebit.Text, out decimalParser) ? decimalParser : 0,
                    Address = this.txtAddress.Text,
                    Contact = this.txtContact.Text
                };

                if (TransType.Equals("insert"))
                {
                    var agent = AgentServices.Add(Agent);
                    if (agent != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }

                }
                else
                {
                    var agent = AgentServices.Update(Agent);
                    if (agent != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }

                this.ID = Agent.Id;
                this.txtID.Text = Agent.Id.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleParser;
                SearchAgent sa = new SearchAgent();
                sa.BringToFront();
                sa.TopMost = true;
                DialogResult res = sa.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.ID = sa.Agent.Id;
                    this.txtID.Text = sa.Agent.Id.ToString();
                    this.txtAgentName.Text = sa.Agent.Name;
                    this.txtStartingDebit.Value = Convert.ToDouble(sa.Agent.StartingDebit);
                    this.txtAddress.Text = sa.Agent.Address;
                    this.txtContact.Text = sa.Agent.Contact;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser;
                decimal decimalParser;

                string TransType = "delete";
                Agent = new Agent
                {
                    Id = this.ID,
                    Name = this.txtAgentName.Text,
                    StartingDebit = decimal.TryParse(this.txtStartingDebit.Text, out decimalParser) ? decimalParser : 0,
                    Address = this.txtAddress.Text,
                    Contact = this.txtContact.Text
                };


                AgentServices.Remove(Agent);
                this.ID = 0;
                MessageBox.Show("Successfully deleted");
                clear();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void clear()
        {
            this.ID = 0;
            this.txtID.Text = string.Empty;
            this.txtAgentName.Text = string.Empty;
            this.txtStartingDebit.Value = 0;
            this.txtContact.Text = string.Empty;
            this.txtAddress.Text = string.Empty;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}

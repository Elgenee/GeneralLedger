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

namespace GeneralLedger.UserControls
{
    public partial class SeachJournalEntry : MetroForm
    {
        public GeneralLedger.Tier.BO.JournalEntry JournalEntry { get; set; }
        public int JournalEntryID { get; set; }

        public int Index { get; set; }

        public SeachJournalEntry()
        {
            JournalEntry = new GeneralLedger.Tier.BO.JournalEntry();
            InitializeComponent();
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
                JournalEntryBAL journalEntryBAL = new JournalEntryBAL();
                List<GeneralLedger.Tier.BO.JournalEntry> journalEntryList = journalEntryBAL.getJournalEntryRecord(this.txtCriteria.Text);
                if ((journalEntryList != null) && journalEntryList.Count > 0)
                {
                    this.dgSeachJournal.ColumnCount = 6;
                    this.dgSeachJournal.RowCount = journalEntryList.Count;

                    for (int i = 0; i < journalEntryList.Count; i++)
                    {

                        this.dgSeachJournal.Rows[i].Cells[0].Value = journalEntryList[i].ID;
                        this.dgSeachJournal.Rows[i].Cells[1].Value = journalEntryList[i].datBatchDate;
                        this.dgSeachJournal.Rows[i].Cells[2].Value = journalEntryList[i].strDescription;
                        this.dgSeachJournal.Rows[i].Cells[3].Value = journalEntryList[i].strTransactionCode;
                        this.dgSeachJournal.Rows[i].Cells[4].Value = journalEntryList[i].GLTranHeader.ID;
                        this.dgSeachJournal.Rows[i].Cells[5].Value = journalEntryList[i].strTransactionNumber;
                    }

                    setRowNumber(this.dgSeachJournal);
                }
                else
                {
                    this.dgSeachJournal.Rows.Clear();
                    this.dgSeachJournal.Refresh();
                    MessageBox.Show("No Result");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgSeachJournal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        this.JournalEntryID = Int32.Parse(this.dgSeachJournal.Rows[e.RowIndex].Cells[0].Value.ToString());
            //        this.JournalEntry = new Tier.BO.JournalEntry
            //        {
            //            ID = Int32.Parse(this.dgSeachJournal.Rows[e.RowIndex].Cells[0].Value.ToString()),
            //            datBatchDate = this.dgSeachJournal.Rows[e.RowIndex].Cells[1].Value.ToString(),
            //            strDescription = this.dgSeachJournal.Rows[e.RowIndex].Cells[2].Value.ToString(),
            //            strTransactionCode = this.dgSeachJournal.Rows[e.RowIndex].Cells[3].Value.ToString(),
            //            GLTranHeader = new GLTranHeader
            //            {
            //                ID = Int32.Parse(this.dgSeachJournal.Rows[e.RowIndex].Cells[4].Value.ToString())
            //            },
            //            strTransactionNumber = this.dgSeachJournal.Rows[e.RowIndex].Cells[5].Value.ToString()
            //        };
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Error:" + ex.Message);
            //}
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            try
            {
                this.Index = this.dgSeachJournal.CurrentCell.RowIndex;
                if (Index >= 0)
                {
                    this.JournalEntryID = Int32.Parse(this.dgSeachJournal.Rows[Index].Cells[0].Value.ToString());
                    this.JournalEntry = new Tier.BO.JournalEntry
                    {
                        ID = Int32.Parse(this.dgSeachJournal.Rows[Index].Cells[0].Value.ToString()),
                        datBatchDate = this.dgSeachJournal.Rows[Index].Cells[1].Value.ToString(),
                        strDescription = this.dgSeachJournal.Rows[Index].Cells[2].Value.ToString(),
                        strTransactionCode = this.dgSeachJournal.Rows[Index].Cells[3].Value.ToString(),
                        GLTranHeader = new GLTranHeader
                        {
                            ID = Int32.Parse(this.dgSeachJournal.Rows[Index].Cells[4].Value.ToString())
                        },
                        strTransactionNumber = this.dgSeachJournal.Rows[Index].Cells[5].Value.ToString()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.DAL;
using GeneralLedger.Utility;

namespace GeneralLedger.Tier.BAL
{
    public class JournalEntryBAL
    {

        public string ManageJournalEntry(Dictionary<string, string> param , string transactionType , List<GLTranDetail> listOfGLTranDetail)
        {

            int intParser;
            decimal decimalParser;
            double doubleParser;


            var journalEntry = new JournalEntry
            {
                 ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                 datBatchDate = param["&BatchDate"],
                 strTransactionNumber = param["&TransactionNo"],
                 strTransactionCode = param["&TransactionCode"],
                 strDescription = param["&Description"],
                 GLTranHeader = new GLTranHeader{
                     ID = int.TryParse(param["&IDGLTranHeader"], out intParser) ? intParser : 0,
                     intIDGLBookType = int.TryParse(param["&IDGLBookType"], out intParser) ? intParser : 0,
                     strDescription = param["&Description"],
                     datBatchDate = param["&BatchDate"],
                     intIDReference = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                     strTransactionCode = param["&TransactionCode"],
                     curCreditAmount = double.TryParse(param["&curCreditAmount"], out doubleParser) ? doubleParser : 0,
                     curDebitAmount = double.TryParse(param["&curDebitAmount"], out doubleParser) ? doubleParser : 0,
                     listOfGLTranDetail = listOfGLTranDetail
                 }
            };

            string ojectToXml = CommonUtil.toXML(journalEntry);
            JournalEntryDAL jeDAL = new JournalEntryDAL();
            //return string.Empty;
           return jeDAL.manage(ojectToXml, transactionType);
        }

        public List<JournalEntry> getJournalEntryRecord(string criteria)
        {

            JournalEntryDAL jeDAL = new JournalEntryDAL();
            return jeDAL.getJournalEntryRecord(criteria);
        }

        public List<GLTranDetail> getTranDetail(int intIDGLTranHeader)
        {
            JournalEntryDAL jeDAL = new JournalEntryDAL();
            return jeDAL.getTranDetail(intIDGLTranHeader);
        }

    }
}

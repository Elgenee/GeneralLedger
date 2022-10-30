using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Utility;
using GeneralLedger.Tier.DAL;
using GeneralLedger.Tier.BO;

namespace GeneralLedger.Tier.BAL
{
    public class COABAL
    {

        public List<COA> getCOA(string criteria)
        {

            COADAL coaDal = new COADAL();
            return coaDal.getCOA(criteria);
        }

        public List<COASub> getCOASub(int icode)
        {

            COADAL coaDal = new COADAL();
            return coaDal.getCOAsub(icode);
        }

        public List<COAGroup> getCoaGoup()
        {
            COADAL coaDal = new COADAL();
            return coaDal.getGroupType();
           
        }

        public List<COA> GetCOAByID(int CoaID)
        {
            COADAL coaDAL = new COADAL();
            return coaDAL.GetByCOAId(CoaID);
           
        }

        public COA GetCOAByCode(string strAccountCode)
        {
            COADAL coaDAL = new COADAL();
            return coaDAL.getCOAbyCode(strAccountCode);
        }

        public COASub GetCOASubByCode(int intIDMasCOA, string strCOASubCode)
        {
            COADAL coasub = new COADAL();
            return coasub.getCOASubByCode(intIDMasCOA, strCOASubCode);
        }

        public string ManageCOA(Dictionary<string, string> param, string transType)
        {
            int intParser;
            //bool boolParser;

            //param.Add("&ID", this.txtCOAID.ToString());
            //param.Add("&COACode", this.txtCOACode.Text);
            //param.Add("&COADesc", this.txtCOADesc.Text);
            //param.Add("&COASide", this.txtAcctSide.Text);
            //param.Add("&COAType", this.txtAcctType.Text);
            //param.Add("&COAGroupID", this.cbCOAGroup.SelectedItem.ToString());

            var coa = new COA
            {
                ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                intIDMasCOAGroup = int.TryParse(param["&COAGroupID"], out intParser) ? intParser : 0,
                strName = param["&COADesc"],
                strAcctSide = param["&COASide"],
                strAcctType = param["&COAType"],
                strCode = param["&COACode"],
                ISOrdering = int.TryParse(param["&ISOrdering"], out intParser) ? intParser : 0,

            };
            
            string ojectToXml = CommonUtil.toXML(coa);
            COADAL coaDal = new COADAL();

            return coaDal.manage(ojectToXml, transType);
        }

        public string ManageCOASub(Dictionary<string, string> param, string transType)
        {
            int intParser;
           
            var coa = new COASub
            {
                ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                intIDCOA = int.TryParse(param["&COACode"], out intParser) ? intParser : 0,
                strCoaSubName = param["&COASubCodeName"],
                strCoaSubCode = param["&COASubCode"],

            };

            string ojectToXml = CommonUtil.toXML(coa);
            COADAL coaDal = new COADAL();

            return coaDal.managesub(ojectToXml, transType);
        }



        //end 
    }
}

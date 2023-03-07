using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace GeneralLedger.Persistence.Repositories
{
    public class tblTBBatchHdrRepository : Repository<tblTBBatchHdr> , ItblTBBatchHdrRepository
    {

        public tblTBBatchHdrRepository(GeneralLedgerContext context) : base(context)
        {
        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

 
    }
}

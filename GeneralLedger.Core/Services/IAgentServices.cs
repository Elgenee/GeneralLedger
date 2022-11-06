using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface IAgentServices
    {
        Agent Add(Agent agent);

        Agent Update(Agent agent);

        void Remove(Agent agent);

        List<Agent> GetAgents();
    }
}

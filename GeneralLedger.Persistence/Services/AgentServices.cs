using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;


namespace GeneralLedger.Persistence.Services
{
    public class AgentServices : IAgentServices
    {
  
        public Agent Add(Agent agent)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.Agent.Add(agent);
                unitOfWork.Complete();
                return agent;
            }
        }

        public List<Agent> GetAgents()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                
                return unitOfWork.Agent.GetAll().ToList();
            }
        }

        public Agent Update(Agent agent)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var result = unitOfWork.Agent.Get(agent.Id);
                result.Name = agent.Name;
                result.Contact = agent.Contact;
                result.Address = agent.Address;
                result.StartingDebit = agent.StartingDebit;
                unitOfWork.Complete();
                return agent;
            }
        }

        public void Remove(Agent agent)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var result = unitOfWork.Agent.Get(agent.Id);
                unitOfWork.Agent.Remove(result);
                unitOfWork.Complete();
            }
        }
    }
}

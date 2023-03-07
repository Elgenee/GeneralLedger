using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;

namespace GeneralLedger.Persistence.Services
{
    public class RoleServices : IRoleServices
    {
        public List<Role> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Role.GetAll().ToList();
            }
        }

        public IEnumerable<Role> GetRolesByUser(Expression<Func<UserRole, bool>> predicate)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Role.GetRolesByUser(predicate);
            }
        }

        public Role GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}

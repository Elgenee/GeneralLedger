using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface IRoleServices
    {
        List<Role> GetAll();
        Role GetUser(int id);

        IEnumerable<Role> GetRolesByUser(Expression<Func<UserRole, bool>> predicate);
    }
}

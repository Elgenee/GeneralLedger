using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace GeneralLedger.Persistence.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {

        public RoleRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<Role> GetRolesByUser(Expression<Func<UserRole, bool>> predicate)
        {
            return GeneralLedgerContext.UserRoles
                .Include(ur => ur.Role)
                .Where(predicate)
                .Select(role => role.Role).ToList();
        }
    }
}

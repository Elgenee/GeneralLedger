using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public User GetUserWithRole(int Id)
        {
            return GeneralLedgerContext.Users
             .Include(u => u.UserRoles)
             .Include(u => u.UserRoles.Select(ur => ur.Role))
             .Where(u => u.Id == Id)
             .SingleOrDefault();
        }

        public IEnumerable<User> GetUserWithRoles(int Id)
        {
            return GeneralLedgerContext.Users
                .Include(u => u.UserRoles)
                .Include(u => u.UserRoles.Select(ur => ur.Role))
                .Where(u => u.Id == Id)
                .ToList();
        }

        public IEnumerable<User> GetUserWithRoles(string criteria)
        {
            return GeneralLedgerContext.Users
               .Include(u => u.UserRoles)
               .Include(u => u.UserRoles.Select(ur => ur.Role))
               .Where(u => u.Username.ToLower().Contains(criteria.ToLower())
               || u.Name.ToLower().Contains(criteria.ToLower())
               || u.UserRoles.Select(ur => ur.Role.Name.ToLower()).Contains(criteria.ToLower())
               ).ToList().Take(100);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface IUserServices
    {
        User Add(User user, List<Role> roles);
        User Update(User user, List<Role> roles);
        void Remove(User user, List<Role> roles);
        List<User> GetAll();
        User GetUser(int id);
        IEnumerable<User> GetUserWithRoles(string criteria);
        bool ResetPassword(int Id);
        User LoginUsername(string username);
        User LoginPassword(string password, string username);
        bool ResetNewPassword(int Id, string password, string username);
    }
}

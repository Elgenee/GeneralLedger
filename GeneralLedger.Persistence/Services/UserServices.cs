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
    public class UserServices : IUserServices
    {
        public User Add(User user, List<Role> roles)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                foreach (var item in roles)
                {
                    user.UserRoles.Add(new UserRole { RoleId = item.Id, UserId = user.Id });
                }
                unitOfWork.User.Add(user);

                unitOfWork.Complete();
                return user;
            }
        }

        public List<User> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.User.GetAll().ToList();
            }
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUserWithRoles(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.User.GetUserWithRoles(criteria).ToList();
            }
        }

        public User LoginPassword(string password, string username)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var userDb = unitOfWork.User.Find(u => u.Username == username && u.Password == password).SingleOrDefault();
                return userDb;
            }
        }

        public User LoginUsername(string username)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {


                var userDb = unitOfWork.User.Find(u => u.Username == username).SingleOrDefault();
                return userDb;
            }
        }

        public void Remove(User user, List<Role> roles)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var userDb = unitOfWork.User.GetUserWithRole(user.Id);
                userDb.Name = user.Name;
                userDb.Username = user.Username;
                unitOfWork.UserRole.RemoveRange(userDb.UserRoles);
                unitOfWork.User.Remove(userDb);
                unitOfWork.Complete();
            }
        }

        public bool ResetNewPassword(int Id, string password, string username)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var userDb = unitOfWork.User.Get(Id);
                userDb.IsResetPassword = false;
                userDb.Password = password;
                unitOfWork.Complete();
                return true;
            }
        }

        public bool ResetPassword(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var userDb = unitOfWork.User.Get(Id);
                userDb.IsResetPassword = true;
                unitOfWork.Complete();
                return true;
            }
        }

        public User Update(User user, List<Role> roles)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var userDb = unitOfWork.User.GetUserWithRole(user.Id);
                userDb.Name = user.Name;
                userDb.Username = user.Username;
                unitOfWork.UserRole.RemoveRange(userDb.UserRoles);
                foreach (var item in roles)
                {

                    userDb.UserRoles.Add(new UserRole { RoleId = item.Id, UserId = user.Id });
                }
                unitOfWork.Complete();
                return userDb;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;

namespace GeneralLedger
{
    public static class UserProfile
    {
        public static User UserUserProfile { get; set; } = new User();
        public static List<Role> UserProfileRoles { get; set; } = new List<Role>();
    }
}

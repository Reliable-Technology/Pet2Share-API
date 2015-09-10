using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;

namespace Pet2Share_API.Service
{
    class AccountManagement
    {
        public User Login(string username, string password)
        {
            bool isAuthenticated = false;

            User user = new User();

            user.IsAuthenticated = false;

            return user;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Identity
{
    public static class Policy
    {
        public const string AdminPolicy = "Admin";
        public const string UserPolicy = "User";
        public const string ManagerPolicy = "Manager";

        public static class RoleClaim
        {
            public const string Admin = "Admin";
            public const string User = "User";
            public const string Manager = "Manager";
        }
    }
}

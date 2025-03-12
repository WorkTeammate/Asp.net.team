using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Admin = "1";
        public const string User = "2";
        public const string BlogManager = "3";
        public const string ColleagueUser = "4";

        public static string GetByRole(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیر سیستم";
                case 2:
                    return "بلاگ منیجر";
                default:
                    return "";
            }
        }
    }
}

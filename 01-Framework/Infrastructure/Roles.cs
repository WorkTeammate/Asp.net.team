using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Admin = "2";
        public const string User = "1";
        public const string BlogManager = "3";
        public const string Seller = "4";

        public static string GetByRole(long id)
        {
            switch (id)
            {
                case 2:
                    return "مدیر سیستم";
                case 1:
                    return "کاربر";
                case 3:
                    return "بلاگ منیجر";
                case 4:
                    return "فروشنده";
                default:
                    return "";
            }
        }
    }
}

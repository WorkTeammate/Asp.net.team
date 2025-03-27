using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application
{
    public interface IAuthHelper
    {
        void SignIn(AuthViewModel account);
        void SignOut();
        bool IsAuthenticated();
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        List<long> GetPermissions();
        long CurrentAccountId();
    }
}

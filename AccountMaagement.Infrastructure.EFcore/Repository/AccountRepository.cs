using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMaagement.Infrastructure.EFcore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _context.Account.Select(x=>new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.FullName,
            }).ToList();
        }

        public Account GetBy(string username)
        {
            return _context.Account.FirstOrDefault(x => x.UserName == username);
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Account.Select(x => new EditAccount
            {
                Id = x.Id,
                FullName = x.FullName,
                Gmail = x.Gmail,
                MobileNumber = x.MobileNumber,
                ProfilePicture = x.ProfilePicture,
                UserName = x.UserName
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Account.Include(x => x.Role).Select(x => new AccountViewModel
            {
                Id= x.Id,
                Fullname= x.FullName,
                CreationDate=x.CreationDate.ToFarsi(),
                Gmail= x.Gmail,
                MobileNumber=x.MobileNumber,
                ProfilePicture= x.ProfilePicture,
                RoleId = x.RoleId,
                Role = x.Role.Name,
                Username = x.UserName
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Gmail))
                query = query.Where(x => x.Gmail.Contains(searchModel.Gmail));

            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            if (!string.IsNullOrWhiteSpace(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));

            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchModel.MobileNumber))
                query = query.Where(x => x.MobileNumber.Contains(searchModel.MobileNumber));

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}

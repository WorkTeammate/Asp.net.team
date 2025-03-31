using _01_Framework.Application;
using _01_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
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
            return _context.Account.Select(x=> new AccountViewModel
            {
                Id=x.Id,
                Fullname = x.Fullname,
            }).ToList();
        }

        public Account GetBy(string username)
        {
            return _context.Account.FirstOrDefault(x => x.Username == username);
        }

        public Account GetByMobile(string Mobile)
        {
            return _context.Account.FirstOrDefault(x => x.Mobile == Mobile);
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Account.Select(x => new EditAccount
            {
                Id = x.Id,
                Fullname=x.Fullname,
                Mobile = x.Mobile,
                Username=x.Username,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Account.Include(x=>x.Role).Select(x => new AccountViewModel
            {
                Id=x.Id,
                Fullname=x.Fullname,
                Mobile=x.Mobile,
                Username=x.Username,
                IsDeleted=x.IsDeleted,
                Role=x.Role.Name,
                ProfilePhoto=x.ProfilePhoto,
                CreationDate=x.CreationDate.ToFarsi()
            });
            if(!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x=>x.Username.Contains(searchModel.UserName));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            return query.OrderByDescending(x=>x.Id).ToList();

        }
    }
}

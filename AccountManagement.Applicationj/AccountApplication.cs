using _01_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using Azure;
using Market.AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository accountRepository
            , IFileUploader fileUploader
            , IAuthHelper authHelper
            , IPasswordHasher passwordHasher,
            IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);

            _accountRepository.SaveChanges();
            return operation.Successful();
        }

        public OperationResult ChangeProfle(ChangeProfile command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var path = $"Account";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);

            account.ChangeProfilePicture(picturePath);
            _accountRepository.SaveChanges();
            return operation.Successful();  
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            account.Edit(command.Fullname, command.Username, command.Mobile, command.RoleId);

            _accountRepository.SaveChanges();


            return operation.Successful();
        }

        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel
            {
                Fullname = account.Fullname,
                Mobile = account.Mobile
            };
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);

            command.ProfilePicture = account.ProfilePhoto;
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var permissions = _roleRepository.Get(account.RoleId)
                .Permission
                .Select(x => x.Code)
                .ToList();

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname
                , account.Username, account.Mobile, permissions, command.ProfilePicture);

            _authHelper.SignIn(authViewModel);
            return operation.Successful();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public OperationResult Register(CreateAccount command)
        {
            var operation = new OperationResult();
            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var path = $"Account";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var account = new Account(command.Fullname, command.Username, password, command.Mobile, picturePath, command.RoleId);

            _accountRepository.Create(account);
            _accountRepository.SaveChanges();

            return operation.Successful();
        }

        public OperationResult RemoveAccount(long id)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            account.Delete();
            _accountRepository.SaveChanges();
            return operation.Successful();
        }

        public OperationResult RestoreAccount(long id)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            account.Restore();
            _accountRepository.SaveChanges();
            return operation.Successful();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}

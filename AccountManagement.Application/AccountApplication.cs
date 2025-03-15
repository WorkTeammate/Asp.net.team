using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IRoleRepository roleRepository, IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
            _authHelper = authHelper;
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

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x =>
                (x.UserName == command.UserName || x.MobileNumber == command.MobileNumber || x.Gmail == command.Gmail) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            account.Edit(command.FullName, command.Gmail, command.MobileNumber,
                command.ProfilePicture,command.RoleId, command.UserName);
            _accountRepository.SaveChanges();
            return operation.Successful();
        }

        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel()
            {
                Fullname = account.FullName,
                MobileNumber = account.MobileNumber,
                Gmail = account.Gmail,
                Id = account.Id,
                Username = account.UserName,
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
            var account = _accountRepository.GetBy(command.Gmail);
            if(account==null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var resault = _passwordHasher.Check(account.Password, command.Password);
            if (!resault.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var permissions = _roleRepository.Get(account.RoleId)
                  .Permissions
                  .Select(x => x.Code)
                  .ToList();

            var authViewModel = new AuthViewModel(account.Id,account.RoleId,account.FullName,account.UserName,account.ProfilePicture,account.Gmail,permissions);
            _authHelper.SignIn(authViewModel);
            return null;

        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();
            if (_accountRepository.Exists(x => x.UserName == command.UserName || x.MobileNumber == command.MobileNumber))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = "Not Set";
            if (!string.IsNullOrWhiteSpace(command.Password))
            {
                 password = _passwordHasher.Hash(command.Password);
            }
            var account = new Account(command.FullName, command.Gmail, command.MobileNumber
                , password, command.ProfilePicture,command.RoleId, command.UserName);

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

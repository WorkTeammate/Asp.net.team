﻿using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(long id);
        OperationResult Register(CreateAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        void Logout();
        List<AccountViewModel> GetAccounts();

        OperationResult RemoveAccount(long id);
        OperationResult RestoreAccount(long id);
        OperationResult ChangeProfle(ChangeProfile command);

    }
}

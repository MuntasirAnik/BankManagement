using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Accounts;
using BankManagementApp.Models;

namespace BankManagementApp.Mappers
{
    public static class AccountMapper
    {
        public static Account ToAccountCreate(this CreateAccountDto dto)
        {
            return new Account
            {
                CustomerId = dto.CustomerId,
                AccountTypeId = dto.AccountTypeId,
                AccountNo = dto.AccountNo,
                Balance = dto.Balance,
                isMultiCurrency = dto.isMultiCurrency,
                OpenedOn = dto.OpenedOn
            };
        }

        public static AccountDto ToAccountDto(this Account accountModel)
        {
            return new AccountDto
            {
                CustomerId = accountModel.CustomerId,
                AccountTypeId = accountModel.AccountTypeId,
                AccountNo = accountModel.AccountNo,
                Balance = accountModel.Balance,
                isMultiCurrency = accountModel.isMultiCurrency,
                OpenedOn = accountModel.OpenedOn,
                Transactions = accountModel.Transactions.Select(x => x.TotransactionDto()).ToList()
            };
        }

    }
}
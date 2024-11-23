using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.AccountType;
using BankManagementApp.Models;

namespace BankManagementApp.Mappers
{
    public static class AccountTypeMapper
    {
        public static AccountTypeDto ToAccountTypeDto(this AccountType accountTypeModel)
        {
            return new AccountTypeDto
            {
                Id = accountTypeModel.Id,
                AccountTypeName = accountTypeModel.AccountTypeName,
                isMultiCurrency = accountTypeModel.isMultiCurrency,
            };
        }

        public static AccountType AccountTypeCreate (this CreateAccoutnTypeDto createAccountTypeDto)
        {
            return new AccountType
            {
                AccountTypeName = createAccountTypeDto.AccountTypeName,
                isMultiCurrency = createAccountTypeDto.isMultiCurrency
            };
        }

         public static AccountType ToAccountTypeUpdate (this UpdateAccountTypeDto accountTypeModel)
        {
            return new AccountType
            {
                AccountTypeName = accountTypeModel.AccountTypeName,
                isMultiCurrency = accountTypeModel.isMultiCurrency
            };
        }
    }
}
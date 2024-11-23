using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.AccountType;
using BankManagementApp.Models;

namespace BankManagementApp.Interfaces
{
    public interface IAccountTypeRepository
    {
        Task<List<AccountType>> GetAllAsync();
        // Task<List<AccountType>> GetByIdAsync();
        Task<AccountType> CreateAsync(AccountType accountTypeDto);
        // Task<List<AccountType>> UpdateAsync();
    }
}
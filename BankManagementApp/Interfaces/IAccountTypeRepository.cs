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
        Task<AccountType?> GetByIdAsync(int id);
        Task<AccountType> CreateAsync(AccountType accountTypeModel);
        Task<AccountType?> UpdateAsync(int id, AccountType accountType);
    }
}
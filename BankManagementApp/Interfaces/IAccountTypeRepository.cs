using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Models;

namespace BankManagementApp.Interfaces
{
    public interface IAccountTypeRepository
    {
        Task<List<AccountType>> GetAllAsync();
        Task<List<AccountType>> GetByIdAsync();
        Task<List<AccountType>> CreateAsync();
        Task<List<AccountType>> UpdateAsync();
    }
}
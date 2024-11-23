using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.DTOs.AccountType;
using BankManagementApp.Interfaces;
using BankManagementApp.Models;

using Microsoft.EntityFrameworkCore;

namespace BankManagementApp.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly ApplicationDBContext _context;
        public AccountTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<AccountType> CreateAsync(AccountType accountType)
        {
            await _context.AccountTypes.AddAsync(accountType);
            await _context.SaveChangesAsync();
            return accountType;  
        }

        public async Task<List<AccountType>> GetAllAsync()
        {
            return await _context.AccountTypes.ToListAsync();
        }

        // public Task<List<AccountType>> GetByIdAsync()
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<List<AccountType>> UpdateAsync()
        // {
        //     throw new NotImplementedException();
        // }
      
    }
}
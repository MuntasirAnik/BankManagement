using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
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

        public Task<List<AccountType>> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AccountType>> GetAllAsync()
        {
            return await _context.AccountTypes.ToListAsync();
        }

        public Task<List<AccountType>> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountType>> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
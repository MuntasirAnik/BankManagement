using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.DTOs.Accounts;
using BankManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementApp.Repository
{
    public class AccountRepository
    {
        private readonly ApplicationDBContext _context;
        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Account> CreateAccountAsync(Account accountModel)
        {
            await _context.Accounts.AddAsync(accountModel);
            await _context.SaveChangesAsync();
            return accountModel;
        }
        public async Task<List<Account>> GetAllAccount()
        {
            return await _context.Accounts.Include(a => a.AccountType).ToListAsync();
        }
       public async Task<List<Account>> GetAllAccountByCustomerId(int customerId)
        {
            return await _context.Accounts
                .Where(c => c.CustomerId == customerId)
                .Include(a => a.AccountType)  
                // .Include(a => a.Customer) 
                .Include(t => t.Transactions)  
                .ToListAsync(); 
        }

        public async Task<Account?> GetAccountByAccountId(int id)
        {
            return await _context.Accounts
            .Include(a => a.AccountType)
            .Include(t => t.Transactions) 
            .FirstOrDefaultAsync(x=>x.Id == id);
        }

    }
}
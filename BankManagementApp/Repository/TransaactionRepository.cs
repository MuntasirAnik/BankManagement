using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.Mappers;
using BankManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementApp.Repository
{
    public class TransaactionRepository
    {
        private readonly ApplicationDBContext _context;
        public TransaactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
        public async Task<List<Transaction>> GetAllTransaction()
        {
            return await _context.Transactions.ToListAsync();
        }
        public async Task<List<Transaction>> GetAllTransactionByAccountId(int accountId)
        {
            return await _context.Transactions
            .Where(c => c.AccountId == accountId)
            .ToListAsync();
        }

        public async Task<Transaction?> GetAccountByAccountId(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x=>x.Id == id);
        }

    }
}
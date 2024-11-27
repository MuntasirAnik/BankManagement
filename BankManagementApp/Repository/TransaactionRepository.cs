using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.DTOs.Transaction;
using BankManagementApp.Mappers;
using BankManagementApp.Models;
using Microsoft.Data.SqlClient;
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
        public async Task<Transaction?> GetTransactionsByAccountId(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<int> GetTodaysTransactionCount(int accountId)
        {
            var today = DateTime.Today;
            return await _context.Transactions
                .Where(t => t.TransactionDate.Date == today  && t.AccountId == accountId)
                .CountAsync();
        }

       public async Task<List<TransactionHistoryDto>> GetTransactionByUserAndAccount(int customerId, int accountId, DateTime startDate, DateTime endDate)
        {
            var customerParam = new SqlParameter("@CustomerId", customerId);
            var accountParam = new SqlParameter("@AccountId", accountId);
            var startDateParam = new SqlParameter("@StartDate", startDate);
            var endDateParam = new SqlParameter("@EndDate", endDate);

            var query = @"
                SELECT cust.Name, acc.Id AS AccountId, acc.AccountNo, trans.Id AS TransactionId, trans.TransactionDate, 
                    trans.Amount, trans.IsCredit, 
                    CASE WHEN trans.IsCredit = 1 THEN 'Credit' ELSE 'Debit' END AS TransactionType,
                    trans.[Description]
                FROM Transactions trans 
                INNER JOIN Accounts acc ON trans.AccountId = acc.Id 
                INNER JOIN Customers cust ON acc.CustomerId = cust.Id
                WHERE acc.CustomerId = @CustomerId 
                AND trans.AccountId = @AccountId
                AND CONVERT(DATE, trans.TransactionDate) BETWEEN @StartDate AND @EndDate";

            var result = await _context.Database.SqlQueryRaw<TransactionHistoryDto>(
                query, customerParam, accountParam, startDateParam, endDateParam
            ).ToListAsync();

            return result;
        }


    }
}
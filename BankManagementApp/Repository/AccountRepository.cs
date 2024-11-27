using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.DTOs.Accounts;
using BankManagementApp.Models;
using Microsoft.Data.SqlClient;
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
        public async Task<Account> GetAccountByNo(string accountNo)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNo == accountNo);
        }
       public async Task<List<Account>> GetAllAccountByCustomerId(int customerId)
        {
            try
            {
                return await _context.Accounts
                .Where(c => c.CustomerId == customerId)
                .Include(a => a.AccountType)  
                .Include(a => a.Customers) 
                .Include(t => t.Transactions)  
                .ToListAsync(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Account?> GetAccountByAccountId(int id)
        {
            return await _context.Accounts
            .Include(a => a.AccountType)
            // .Include(a => a.Customers) 
            .Include(t => t.Transactions) 
            .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Account?> GetAccountById(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<AccountSummaryDto> GetAccountSummary(int customerId, int accountId, DateTime startDate, DateTime endDate)
        {
            var customerParam = new SqlParameter("@CustomerId", customerId);
            var accountParam = new SqlParameter("@AccountId", accountId);
            var startDateParam = new SqlParameter("@StartDate", startDate);
            var endDateParam = new SqlParameter("@EndDate", endDate);

            var query = @"
                SELECT cust.Name, cust.Address, cust.ContactNo, acc.accountNo,
                    (SELECT SUM(t.Amount)
                    FROM Transactions t
                    WHERE t.AccountId = 1 
                    AND CONVERT(DATE, t.TransactionDate) < '2024-11-26') AS OpeningBalance,
                    SUM(CASE WHEN IsCredit = 1 THEN Amount ELSE 0 END) AS TotalCredit,
                    SUM(CASE WHEN IsCredit = 0 THEN Amount ELSE 0 END) AS TotalDebit,
                    ( 
                        (SELECT SUM(t.Amount)
                        FROM Transactions t
                        WHERE t.AccountId = 1 
                        AND CONVERT(DATE, t.TransactionDate) < '2024-11-26') 
                        + SUM(CASE WHEN IsCredit = 1 THEN Amount ELSE 0 END)
                        - SUM(CASE WHEN IsCredit = 0 THEN Amount ELSE 0 END)
                    ) AS ClosingBalance
                FROM Transactions t
                INNER JOIN Accounts acc on acc.Id = t.AccountId
                INNER JOIN Customers cust on cust.Id = acc.CustomerId
                WHERE AccountId = 1 
                AND CONVERT(DATE, TransactionDate) BETWEEN '2024-11-26' AND '2024-11-27'
                GROUP By cust.Name, cust.Address, cust.ContactNo, acc.accountNo";

            var result = await _context.Database.SqlQueryRaw<AccountSummaryDto>(
                query, customerParam, accountParam, startDateParam, endDateParam
            ).FirstOrDefaultAsync();

            return result;
        }
    }
}
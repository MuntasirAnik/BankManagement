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
                    ISNULL(
                        (SELECT SUM(t.Amount)
                        FROM Transactions t
                        WHERE t.AccountId = @accountId
                        AND CONVERT(DATE, t.TransactionDate) < @startDate), 0
                    ) AS OpeningBalance,
                    ISNULL(SUM(CASE WHEN t.IsCredit = 1 THEN t.Amount ELSE 0 END), 0) AS TotalCredit,
                    ISNULL(SUM(CASE WHEN t.IsCredit = 0 THEN t.Amount ELSE 0 END), 0) AS TotalDebit,
                    (
                        ISNULL(
                            (SELECT SUM(t.Amount)
                            FROM Transactions t
                            WHERE t.AccountId = @accountId 
                            AND CONVERT(DATE, t.TransactionDate) < @startDate), 0
                        )
                        + ISNULL(SUM(CASE WHEN t.IsCredit = 1 THEN t.Amount ELSE 0 END), 0)
                        - ISNULL(SUM(CASE WHEN t.IsCredit = 0 THEN t.Amount ELSE 0 END), 0)
                    ) AS ClosingBalance
                FROM Accounts acc
                LEFT JOIN Transactions t ON acc.Id = t.AccountId 
                    AND CONVERT(DATE, t.TransactionDate) BETWEEN @startDate AND @endDate
                INNER JOIN Customers cust ON cust.Id = acc.CustomerId
                WHERE acc.Id = @accountId
                GROUP BY cust.Name, cust.Address, cust.ContactNo, acc.accountNo";


            var result = await _context.Database.SqlQueryRaw<AccountSummaryDto>(
                query, customerParam, accountParam, startDateParam, endDateParam
            ).FirstOrDefaultAsync();

            return result;
        }
    }
}
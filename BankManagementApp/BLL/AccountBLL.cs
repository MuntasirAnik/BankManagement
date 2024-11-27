using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Accounts;
using BankManagementApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.BLL
{
    public class AccountBLL
    {
        private readonly AccountRepository _accountRepo;
        private readonly TransaactionRepository _transactionRepo;
        public AccountBLL(AccountRepository accountRepo, TransaactionRepository transaactionRepo)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transaactionRepo;
        }

        public async Task<(bool IsSuccess,string ErrorMessag,AccountStatementDto)> AccountStatement([FromRoute]int customerId, [FromRoute] int accountId, [FromRoute] DateTime startDate, [FromRoute] DateTime endDate)
        {
            var account = await _accountRepo.GetAccountById(accountId);
            if(account == null) return (false, "Account not found", null);
            var accountSummary =await _accountRepo.GetAccountSummary(customerId, accountId,startDate,endDate);
            var transactionHistory =await _transactionRepo.GetTransactionByUserAndAccount(customerId, accountId,startDate,endDate);

            var accountStatement = new AccountStatementDto
            {
                AccountSummary = accountSummary, 
                TransactionHistory = transactionHistory 
            };
            return (true,"", accountStatement);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Transaction;
using BankManagementApp.Mappers;
using BankManagementApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransaactionRepository _transaactionRepo;
        private readonly AccountRepository  _accountRepo;
        public TransactionController(TransaactionRepository transaactionRepo, AccountRepository accountRepo)
        {
            _transaactionRepo = transaactionRepo;
            _accountRepo = accountRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto transactionDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var account = await _accountRepo.GetAccountByAccountId(transactionDto.AccountId.Value);

            if (account == null) 
                return NotFound("Account not found.");

            if (transactionDto.IsCredit)
            {
                if(transactionDto.Amount >0)
                {
                    account.balance = transactionDto.Amount;
                }
                // account.Balance += transactionDto.Amount; 
            }
            else
            {
                account.balance = -transactionDto.Amount;
                // if (account.Balance < transactionDto.Amount)
                //     return BadRequest("Insufficient balance.");

                // account.Balance -= transactionDto.Amount; 
            }
            var transaction = transactionDto.ToCreateTransaction();

            await _transaactionRepo.CreateTransaction(transaction);
            // await _accountRepo.UpdateAccount(account);

            return Ok(new
            {
                Message = "Transaction successful.",
                Transaction = transaction,
                NewBalance = account.balance,
            });
        }

        [HttpGet("account/{accountId:int}")]
        public async Task<IActionResult> GetAllTrasnsactionBbyAccountId(int accountId)
        {
            var transactions = await _transaactionRepo.GetAllTransactionByAccountId(accountId);
            if(transactions == null)
            {
                return NotFound();
            }
            return Ok(transactions);
        }
    }
}
using BankManagementApp.DTOs.Accounts;
using BankManagementApp.DTOs.Transaction;
using BankManagementApp.Mappers;
using BankManagementApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository _accountRepo;
        private readonly TransaactionRepository _transactionRepo;
        // private readonly Transac
        public AccountController(AccountRepository accountRepo, TransaactionRepository transaactionRepo)
        { 
            _accountRepo = accountRepo;  
            _transactionRepo = transaactionRepo;        
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountDto accountDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var accountTypeModel = accountDto.ToAccountCreate();
            var account = await _accountRepo.CreateAccountAsync(accountTypeModel);
            
            //opening balance
            if (accountDto.Balance > 0)
            {
                var transactionDto = new CreateTransactionDto
                {
                    AccountId = account.Id, 
                    TransactionDate = DateTime.Now,
                    Amount = accountDto.Balance,
                    IsCredit = true, 
                    Description = "Initial deposit"
                };

                var transaction = transactionDto.ToCreateTransaction();
                await _transactionRepo.CreateTransaction(transaction);
            }
            return Ok(accountDto); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccount()
        {
            var accountType = await _accountRepo.GetAllAccount();
            if(accountType == null)
            {
                return NotFound();
            }
            return Ok(accountType);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllAccountByAccountId(int id)
        {
            var accounts = await _accountRepo.GetAccountByAccountId(id);
            if(accounts == null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetAllAccountByCustomer(int customerId)
        {
            var accounts = await _accountRepo.GetAllAccountByCustomerId(customerId);
            if(accounts == null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }
    }
}
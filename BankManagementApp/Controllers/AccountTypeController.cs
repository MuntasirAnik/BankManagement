using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/AccountType")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly AccountTypeRepository _accountTypeRepo;

        public AccountTypeController(ApplicationDBContext context, AccountTypeRepository accountTypeRepo)
        {
            _accountTypeRepo = accountTypeRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccountType()
        {
            var accountType = await _accountTypeRepo.GetAllAsync();
            return Ok(accountType);
        }
        
    }
}
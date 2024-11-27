using BankManagementApp.Data;
using BankManagementApp.DTOs.AccountType;
using BankManagementApp.Interfaces;
using BankManagementApp.Mappers;
using BankManagementApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/accounttype")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IAccountTypeRepository _accountTypeRepo;

        public AccountTypeController(ApplicationDBContext context, IAccountTypeRepository accountTypeRepo)
        {
            _accountTypeRepo = accountTypeRepo;
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetAllAccountType()
        {
            var accountType = await _accountTypeRepo.GetAllAsync();
            if(accountType == null)
            {
                return NotFound();
            }
            return Ok(accountType);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var accountType = await _accountTypeRepo.GetByIdAsync(id);
            if(accountType == null)
            {
                return NotFound();
            }   
            return Ok(accountType.ToAccountTypeDto());   
        }    

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create([FromBody] CreateAccoutnTypeDto accoutnTypeDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var accountTypeModel = accoutnTypeDto.AccountTypeCreate();
            await _accountTypeRepo.CreateAsync(accountTypeModel);
            return Ok(accountTypeModel); 
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Employee")]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAccountTypeDto updateAccountTypeDto)
        {
            var accountType = await _accountTypeRepo.UpdateAsync(id, updateAccountTypeDto.ToAccountTypeUpdate());

            if(accountType == null)
            {
                return NotFound("Account Type Not found");
            }
            return Ok(accountType.ToAccountTypeDto());
        }
    }
}
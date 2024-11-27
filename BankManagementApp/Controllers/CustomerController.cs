using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Auth;
using BankManagementApp.DTOs.Customer;
using BankManagementApp.Interfaces;
using BankManagementApp.Mappers;
using BankManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public CustomerController(ICustomerRepository customerRepo,ITokenService tokenService,UserManager<AppUser> userManager)
        {
            _customerRepo = customerRepo;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto customerDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var customer = customerDto.ToCustomerFromCreate();
            await _customerRepo.CreateAsync(customer);

            var appUser = new AppUser
                {
                    UserName = customerDto.Name,
                    Email = customerDto.Email,
                };
            var createdUser = await _userManager.CreateAsync(appUser, "User@432!");
            if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Customer");
                    if (roleResult.Succeeded)
                    {
                        // return Ok(new NewUserDto
                        // {
                            // UserName = appUser.UserName,
                            // Email = appUser.Email,
                            // Token = await _tokenService.CreateToken(appUser),
                            await _tokenService.CreateToken(appUser);
                            // Role = "Customer"
                        // } );
                    }
                    else
                    {
                        await _userManager.DeleteAsync(appUser); // Rollback user creation
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            return Ok(customer);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customer = await _customerRepo.GetAllAsync();
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            if(customer == null)
            {
                return NotFound();
            }   
            return Ok(customer.ToCustomerDto());   
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var customer = await _customerRepo.UpdateAsync(id, updateCustomerDto.ToCustomerFromUpdate());

            if(customer == null)
            {
                return NotFound("Customer Not found");
            }
            return Ok(customer.ToCustomerDto());
        }
    }
}
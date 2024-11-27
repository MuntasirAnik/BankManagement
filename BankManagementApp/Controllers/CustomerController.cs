using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Customer;
using BankManagementApp.Interfaces;
using BankManagementApp.Mappers;
using BankManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto customerDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var customer = customerDto.ToCustomerFromCreate();
            await _customerRepo.CreateAsync(customer);
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
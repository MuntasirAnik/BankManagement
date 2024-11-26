using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Auth;
using BankManagementApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register/customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterDto registerDto)
        {
            return await RegisterWithRole(registerDto, "Customer");
            // try
            // {
            //     if(!ModelState.IsValid) return BadRequest(ModelState);

            //     var appUser = new AppUser
            //     {
            //         UserName = registerDto.Username,
            //         Email = registerDto.Email,
            //     };

            //     var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            //     if(createdUser.Succeeded)
            //     {
            //         var roleResult = await _userManager.AddToRoleAsync(appUser, "Customer");
            //         if(roleResult.Succeeded)
            //         {
            //             return Ok("User Created");
            //         }
            //         else
            //         {
            //             return StatusCode(500, roleResult.Errors);
            //         }
            //     }
            //     else{
            //         return StatusCode(500, createdUser.Errors);
            //     }
            // }
            // catch(Exception ex)
            // {
            //     return StatusCode(500, ex.Message);
            // }
            
        }
        
        [HttpPost("register/admin")]
        // [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
        {
            return await RegisterWithRole(registerDto, "Admin");
        }

        [HttpPost("register/employee")]
        // [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterDto registerDto)
        {
            return await RegisterWithRole(registerDto, "Employee");
        }
        private async Task<IActionResult> RegisterWithRole(RegisterDto registerDto, string role)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, role);
                    if (roleResult.Succeeded)
                    {
                        return Ok(new { Message = $"User registered as {role}" });
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
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
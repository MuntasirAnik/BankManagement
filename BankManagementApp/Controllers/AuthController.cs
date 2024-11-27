using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Auth;
using BankManagementApp.Interfaces;
using BankManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankManagementApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        public AuthController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
        }

        [HttpPost("register/customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterDto registerDto)
        {
            return await RegisterWithRole(registerDto, "Customer");
        }
        
        [HttpPost("register/admin")]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
        {
            return await RegisterWithRole(registerDto, "Admin");
        }

        [HttpPost("register/employee")]
        [Authorize(Roles = "Admin")] 
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
                        return Ok(new NewUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = await _tokenService.CreateToken(appUser),
                            Role = role
                        } );
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
            if(user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded) return Unauthorized("Username or password is incorrect");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email= user.Email,
                    Token = await _tokenService.CreateToken(user) 
                }
            );
        }

    }
}
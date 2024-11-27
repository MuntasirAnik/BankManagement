using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly AccountBLL _accountBLL;
        public ReportController(AccountBLL accountBLL)
        {
            _accountBLL = accountBLL;
        }

        [HttpGet]
        [Authorize(Roles = "Employee,Manager,Admin")]
        [Route("accountstatement/{customerId:int}/{accountId:int}/{startDate:datetime}/{endDate:datetime}")]
        public async Task<IActionResult> AccountStatement(
            [FromRoute] int customerId, 
            [FromRoute] int accountId,
            [FromRoute] DateTime startDate, 
            [FromRoute] DateTime endDate
        )
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _accountBLL.AccountStatement(customerId,accountId,startDate,endDate);
            if(result.IsSuccess)
            {
                return Ok(result.Item3);
            }
            return BadRequest(result.ErrorMessag);
        }
    }
}
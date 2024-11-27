
using BankManagementApp.BLL;
using BankManagementApp.DTOs.FundTransfer;
using BankManagementApp.DTOs.Transaction;
using BankManagementApp.Mappers;
using BankManagementApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/fundtransfer")]
    [ApiController]
    public class FundTransferController : ControllerBase
    {
        private readonly FundTransferBLL _fundTransferBLL;
        public FundTransferController( FundTransferBLL fundTransferBLL)
        {
            _fundTransferBLL = fundTransferBLL;
        }
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([FromBody] CreateFundTransferDto createFundTransferDto)
        {
            if (!ModelState.IsValid)
             return BadRequest(ModelState);

            var result = await _fundTransferBLL.ProcessFundTransfer(createFundTransferDto);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    Message = "Transaction successful.",
                    TransferFrom = createFundTransferDto.TransferFrom,
                    TransferTo = createFundTransferDto.TransferTo,
                    TransferAmount = createFundTransferDto.TransferAmount,
                    NewBalance = result.NewBalance
                });
            }
            return BadRequest(result.ErrorMessage);
        }
    }
    
}
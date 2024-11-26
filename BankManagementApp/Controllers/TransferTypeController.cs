using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Transaction;
using BankManagementApp.DTOs.TransferType;
using BankManagementApp.Mappers;
using BankManagementApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementApp.Controllers
{
    [Route("api/transfertype")]
    [ApiController]
    public class TransferTypeController : ControllerBase
    {
        private readonly TransferTypeRepository _transferRepo;
        public TransferTypeController(TransferTypeRepository transferRepo)
        {
            _transferRepo = transferRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transferTypes = await _transferRepo.getAllAsync();
            if(transferTypes == null)
            {
                return NotFound();
            }
            return Ok(transferTypes);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransferTypeDto createTransferTypeDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var tarnsferType = createTransferTypeDto.ToCreateTransferType();
            await _transferRepo.Create(tarnsferType);
            
            return Ok(tarnsferType);
        } 
    }
}
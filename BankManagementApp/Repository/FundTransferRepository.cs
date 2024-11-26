using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementApp.Repository
{
    public class FundTransferRepository
    {
        private readonly ApplicationDBContext _context;
        public FundTransferRepository(ApplicationDBContext context)
        {
            _context = context;
        }
         public async Task<List<FundTransfer>> getAllAsync()
        {
            return await _context.FundTransfers.ToListAsync();
        }
        public async Task<FundTransfer> Create(FundTransfer fundTransferModel)
        {
            await _context.FundTransfers.AddAsync(fundTransferModel);
            await _context.SaveChangesAsync();
            return fundTransferModel;
        }
    }
}
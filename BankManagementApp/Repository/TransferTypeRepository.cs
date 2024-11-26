using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementApp.Repository
{
    public class TransferTypeRepository
    {
        private readonly ApplicationDBContext _context;
        public TransferTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<TransferType>> getAllAsync()
        {
            return await _context.TransferTypes.ToListAsync();
        }
        public async Task<TransferType> Create(TransferType transferTypeModel)
        {
            await _context.TransferTypes.AddAsync(transferTypeModel);
            await _context.SaveChangesAsync();
            return transferTypeModel;
        }
    }
}
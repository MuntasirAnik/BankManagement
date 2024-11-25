using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.Data;
using BankManagementApp.Interfaces;
using BankManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;
        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;            
        }
        public async Task<Customer> CreateAsync(Customer customerModel)
        {
            await _context.Customers.AddAsync(customerModel);
            await _context.SaveChangesAsync();
            return customerModel;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer == null ? null : customer;
        }

        public async Task<Customer?> UpdateAsync(int id, Customer customerModel)
        {
             var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null) return null;

            existingCustomer.Name = customerModel.Name;
            existingCustomer.Address = customerModel.Address;
            existingCustomer.ContactNo = customerModel.ContactNo;

            await _context.SaveChangesAsync();
            return existingCustomer;
        }
    }
}
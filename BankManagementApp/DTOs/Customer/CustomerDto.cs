using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Accounts;
using BankManagementApp.Models;

namespace BankManagementApp.DTOs.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public List<AccountDto>? Accounts{ get; set; }
    }
}
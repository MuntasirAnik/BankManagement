using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Transaction;

namespace BankManagementApp.DTOs.Accounts
{
    public class AccountDto
    {
        public int? CustomerId { get; set; } 
        public int AccountTypeId { get; set; }
        public string AccountNo { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public bool isMultiCurrency { get; set; }
        public DateTime OpenedOn { get; set; }
        public List<TransactionDto>? Transactions{ get; set; }
    }
}
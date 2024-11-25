using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        public int? AccountId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public bool IsCredit { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
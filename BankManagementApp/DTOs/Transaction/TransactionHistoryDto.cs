using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.Transaction
{
    public class TransactionHistoryDto
    {
        public string Name { get; set; }
        public int AccountId { get; set; }
        public string AccountNo { get; set; }
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsCredit { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
    }
}
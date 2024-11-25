using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankManagementApp.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public bool IsCredit { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

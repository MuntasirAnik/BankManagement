using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BankManagementApp.Models
{
    [Table("Accounts")]
    public class Account
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customers { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountNo { get; set; } = string.Empty;
        public decimal Balance { get; set; } = 0;
        public bool isMultiCurrency { get; set; } = false;
        public DateTime OpenedOn { get; set; } = DateTime.Now;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

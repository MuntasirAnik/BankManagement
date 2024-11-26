using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.Models
{
    public class FundTransfer
    {
        public int Id { get; set; }
        public int TransferTypeId { get; set; }
        public string? TransferTo { get; set; }
        public string? TransferFrom { get; set; }
        public decimal TransferAmount { get; set; }
        public DateTime TransferTime { get; set; } = DateTime.Now;
    }
}
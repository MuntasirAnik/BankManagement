using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.FundTransfer
{
    public class FundTransferDto
    {
        public int TransferTypeId { get; set; }
        public string? TransferFrom { get; set; }
        public string? TransferTo { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
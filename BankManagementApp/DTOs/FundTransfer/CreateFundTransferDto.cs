using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.FundTransfer
{
    public class CreateFundTransferDto
    {
        [Required]
        public int TransferTypeId { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Account No must be over 10 digit")]
        [MaxLength(17, ErrorMessage = "Account No can not be over 17 digit")]
        public string? TransferFrom { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Account No must be over 10 digit")]
        [MaxLength(17, ErrorMessage = "Account No can not be over 17 digit")]
        public string? TransferTo { get; set; }
        [Required]
        public decimal TransferAmount { get; set; }
    }
}
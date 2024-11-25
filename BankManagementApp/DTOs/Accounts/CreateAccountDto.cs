using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.Accounts
{
    public class CreateAccountDto  
    {
        public int CustomerId { get; set; } 
        public int AccountTypeId { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Account No must be over 10 digit")]
        [MaxLength(17, ErrorMessage = "Account No can not be over 17 digit")]
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenedOn { get; set; }

    }

}
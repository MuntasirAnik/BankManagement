using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.AccountType
{
    public class UpdateAccountTypeDto
    {
        [Required]
        public string AccountTypeName {get; set;} = string.Empty;
        [Required]
        public bool isMultiCurrency { get; set; } = false;
    }
}
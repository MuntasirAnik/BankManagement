using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.Models
{
    [Table("AccountTypes")]
    public class AccountType
    {
        public int Id { get; set; }
        [Required]
        public string AccountTypeName { get; set; }
        [Required]
        public bool isMultiCurrency { get; set; } = false;
        
    }
}
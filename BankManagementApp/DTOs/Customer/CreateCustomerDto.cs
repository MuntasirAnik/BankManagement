using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.Customer
{
    public class CreateCustomerDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(11, ErrorMessage = "Contact no cannot be over 11 Characters")]
        public string ContactNo { get; set; } = string.Empty;
    }
}
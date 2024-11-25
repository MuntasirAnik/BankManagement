using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.TransferType
{
    public class TransferTypeDto
    {
        public string TransferTypeName { get; set; } 
        public string Description { get; set; }
    }
}
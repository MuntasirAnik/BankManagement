using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.AccountType
{
    public class AccountTypeDto
    {
        public int Id { get; set; }
        public string AccountTypeName {get; set;} = string.Empty;
        public bool isMultiCurrency { get; set; } = false;
    }
}
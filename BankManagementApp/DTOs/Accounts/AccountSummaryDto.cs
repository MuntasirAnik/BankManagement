using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.DTOs.Accounts
{
    public class AccountSummaryDto
    {
        public string name { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string AccountNo { get; set; }
        public decimal? OpeningBalance { get; set; }
        public decimal? TotalCredit { get; set; }
        public decimal? TotalDebit { get; set; }
        public decimal? ClosingBalance { get; set; }

    }
}
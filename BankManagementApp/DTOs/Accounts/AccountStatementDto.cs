using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Transaction;

namespace BankManagementApp.DTOs.Accounts
{
    public class AccountStatementDto
    {
        public AccountSummaryDto AccountSummary { get; set; }
        public List<TransactionHistoryDto> TransactionHistory { get; set; }
    }
}
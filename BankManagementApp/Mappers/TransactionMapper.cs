using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.Transaction;
using BankManagementApp.Models;

namespace BankManagementApp.Mappers
{
    public static class TransactionMapper
    {
        public static Transaction ToCreateTransaction(this CreateTransactionDto transactionDto)
        {
            return new Transaction
            {
                AccountId = transactionDto.AccountId,
                Amount = transactionDto.Amount,
                IsCredit = transactionDto.IsCredit,
                Description = transactionDto.Description,
            };
        }

        public static TransactionDto TotransactionDto(this Transaction transactionModel)
        {
            return new TransactionDto
            {
                AccountId = transactionModel.AccountId,
                Amount = transactionModel.Amount,
                IsCredit = transactionModel.IsCredit,
                Description = transactionModel.Description,
            };
        }
    }
}
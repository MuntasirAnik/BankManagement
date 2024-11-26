using BankManagementApp.DTOs.FundTransfer;
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
        public static Transaction ToTransactionFromFundTransfer(this CreateFundTransferDto fundTransferDto, int accountId, bool isCredit, string description)
        {
            if (fundTransferDto == null) throw new ArgumentNullException(nameof(fundTransferDto));
            return new Transaction
            {
                AccountId = accountId,
                Amount = fundTransferDto.TransferAmount,
                IsCredit = isCredit,
                Description = description,
                TransactionDate = DateTime.Now
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
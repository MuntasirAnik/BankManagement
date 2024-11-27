using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.FundTransfer;
using BankManagementApp.Mappers;
using BankManagementApp.Repository;

namespace BankManagementApp.BLL
{
    public class FundTransferBLL
    {
        private readonly FundTransferRepository _fundTransferRepo;
        private readonly AccountRepository  _accountRepo;
        private readonly TransaactionRepository _transactionRepo;
        public FundTransferBLL(FundTransferRepository fundTransferRepo,AccountRepository accountRepo, TransaactionRepository transaactionRepo)
        {
            _fundTransferRepo = fundTransferRepo;
            _accountRepo = accountRepo;
            _transactionRepo = transaactionRepo;
        }

        public async Task<(bool IsSuccess, string ErrorMessage, decimal NewBalance)> ProcessFundTransfer(CreateFundTransferDto createFundTransferDto)
        {
            
            var accountFrom = await _accountRepo.GetAccountByNo(createFundTransferDto.TransferFrom);
            if(await _transactionRepo.GetTodaysTransactionCount(accountFrom.Id) == 2)
            {
                return (false, "You have already reached your daily transaction limit.", 0);
            }
            var accountTo = await _accountRepo.GetAccountByNo(createFundTransferDto.TransferTo);

            if (accountFrom == null || accountTo == null)
                return (false, "Account not found.", 0);

            if (createFundTransferDto.TransferAmount <= 0)
                return (false, "Invalid transfer amount.", 0);

            var fundTransfer = createFundTransferDto.ToCreateFundTransfer();
            await _fundTransferRepo.Create(fundTransfer);

            accountFrom.Balance = -createFundTransferDto.TransferAmount;
            accountTo.Balance = +createFundTransferDto.TransferAmount;
            // await _accountRepo.Update(accountFrom);
            // await _accountRepo.Update(accountTo);

            var transactionFrom = createFundTransferDto.ToTransactionFromFundTransfer(
                accountId: accountFrom.Id,
                isCredit: false,
                description: $"Fund transfer to {createFundTransferDto.TransferTo}"
            );
            await _transactionRepo.CreateTransaction(transactionFrom);

            var transactionTo = createFundTransferDto.ToTransactionFromFundTransfer(
                accountId: accountTo.Id,
                isCredit: true,
                description: $"Fund received from {createFundTransferDto.TransferFrom}"
            );
            await _transactionRepo.CreateTransaction(transactionTo);

            return (true, null, accountFrom.Balance);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.FundTransfer;
using BankManagementApp.Models;

namespace BankManagementApp.Mappers
{
    public static class FundTransferMapper
    {
        public static FundTransfer ToCreateFundTransfer(this CreateFundTransferDto fundTransferModel)
        {
            return new FundTransfer
            {
                TransferTypeId = fundTransferModel.TransferTypeId,
                TransferFrom = fundTransferModel.TransferFrom,
                TransferTo = fundTransferModel.TransferTo,
                TransferAmount = fundTransferModel.TransferAmount
            };
        }

        public static FundTransferDto ToFundTransferDto(this FundTransferDto fundTransferModel)
        {
            return new FundTransferDto
            {
                TransferTypeId = fundTransferModel.TransferTypeId,
                TransferFrom = fundTransferModel?.TransferFrom,
                TransferTo = fundTransferModel?.TransferTo,
                TransferAmount = fundTransferModel.TransferAmount
            };
        } 
    }
}
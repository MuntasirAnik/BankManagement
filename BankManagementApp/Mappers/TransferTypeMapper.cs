using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementApp.DTOs.TransferType;
using BankManagementApp.Models;

namespace BankManagementApp.Mappers
{
    public static class TransferTypeMapper
    {

        public static TransferType ToCreateTransferType(this CreateTransferTypeDto transferTypeModel)
        {
            return new TransferType
            {
                TransferTypeName = transferTypeModel.TransferTypeName,
                Description = transferTypeModel?.Description,
            };
        }
        public static TransferTypeDto ToTransferTypeDto(this TransferTypeDto transferType)
        {
            return new TransferTypeDto
            {
                TransferTypeName = transferType.TransferTypeName,
                Description = transferType.Description,
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.Models
{
    public class TransferType
    {
        public int Id { get; set; }
        public string TransferTypeName  { get; set; }
        public string Description { get; set; }
    }
}
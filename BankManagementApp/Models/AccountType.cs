
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementApp.Models
{
    [Table("AccountTypes")]
    public class AccountType
    {
        public int Id { get; set; }
        public string AccountTypeName { get; set; } = string.Empty;
        public bool isMultiCurrency { get; set; } = false;
        
    }
}
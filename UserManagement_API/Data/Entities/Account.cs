using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement_API.Data.Entities
{
    public class Account
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public virtual User User { get; set; }
    }
}
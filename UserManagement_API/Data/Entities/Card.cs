using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement_API.Data.Entities
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string CardHolder { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double ExpenseLimit { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement_API.Data.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CitizenNum { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public int StatusID { get; set; }
        // public DateTime LastActivityDate { get; set; }

        // public virtual List<Address> Addresses { get; set; }
        // public virtual Password Password { get; set; }
        // public virtual List<Card> Cards { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement_API.Data.Entities
{
    public class Password
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PasswordId { get; set; }
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string OldPassword { get; set; }
        public int PasswordRetryCount { get; set; }
        public DateTime PasswordCreationDate { get; set; }
    }
}
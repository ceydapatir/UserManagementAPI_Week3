using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement_API.Models.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CitizenNum { get; set; }
        public string BirthDate { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public string Status { get; set; }
    }
}
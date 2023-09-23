using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement_API.Data.Entities;

namespace UserManagement_API.Models.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CitizenNum { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        // public virtual List<AddressDTO> Addresses { get; set; }
        // public virtual Password Password { get; set; }
    }
}
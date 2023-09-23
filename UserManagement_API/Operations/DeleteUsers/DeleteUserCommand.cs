using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement_API.Data.Context;

namespace UserManagement_API.Operations.DeleteUsers
{
    public class DeleteUserCommand
    {
        public int UserId { get; set; }
        private readonly UserDBContext _context;

        public DeleteUserCommand(UserDBContext context, int id){
            _context = context;
            UserId = id;
        }

        // Data with UserId is searched, if any it is deleted, otherwise it throws an error.
        public void Handle(){
            var user = _context.Users.Where(i => i.UserId == UserId).SingleOrDefault();
            if(user is null)
                throw new InvalidOperationException("There is no customer with this id.");
            else
                _context.Users.Remove(user);
                _context.SaveChanges();
        }
    }
}
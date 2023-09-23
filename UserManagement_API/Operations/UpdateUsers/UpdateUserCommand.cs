using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManagement_API.Data.Context;
using UserManagement_API.Data.Entities;
using UserManagement_API.Models.DTO;

namespace UserManagement_API.Operations.UpdateUsers
{
    public class UpdateUserCommand
    {
        public int UserId { get; set; }
        public UserDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly UserDBContext _context;

        public UpdateUserCommand(UserDBContext context, IMapper mapper, UserDTO model, int id){
            _context = context;
            _mapper = mapper;
            Model = model;
            UserId = id;
        }

        // Data with UserId is searched, if any it is replaced with a new one, otherwise it throws an error.
        public void Handle(){
            var user = _context.Users.Where(i => i.UserId == UserId).SingleOrDefault();
            if( user is null )
                throw new InvalidOperationException("There is no customer with this id.");
            else
                user = _mapper.Map(Model,user); // Reverse user with UserViewModel
                _context.SaveChanges();
        }
    }
}
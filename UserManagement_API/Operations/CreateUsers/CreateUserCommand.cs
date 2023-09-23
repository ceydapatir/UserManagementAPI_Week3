using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManagement_API.Data.Context;
using UserManagement_API.Models.DTO;
using UserManagement_API.Data.Entities;

namespace UserManagement_API.Operations.CreateUsers
{
    public class CreateUserCommand
    {
        public UserDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly UserDBContext _context;

        public CreateUserCommand(UserDBContext context, IMapper mapper, UserDTO model){
            _context = context;
            _mapper = mapper;
            Model = model;
        }

        // If there is no other customer with the same name, it will be added and if there is, it will throw an error.
        public void Handle(){
            var user = _context.Users.Where(i => i.CitizenNum == Model.CitizenNum).SingleOrDefault();
            if( user is not null )
                throw new InvalidOperationException("You are already our customer.");
            else
                user = _mapper.Map<User>(Model); // Convert Model from UserViewModel to User type
                _context.Users.Add(user);
                _context.SaveChanges();
        }
    }
}
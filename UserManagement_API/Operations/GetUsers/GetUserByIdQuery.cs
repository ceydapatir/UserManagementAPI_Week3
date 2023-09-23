using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManagement_API.Data.Context;
using UserManagement_API.Models.ViewModel;

namespace UserManagement_API.Operations.GetUsers
{
    public class GetUserByIdQuery
    {
        public int UserId { get; set; }
        private readonly IMapper _mapper;
        private readonly UserDBContext _context;
        public GetUserByIdQuery(UserDBContext context, IMapper mapper, int id){
            _context = context;
            _mapper = mapper;
            UserId = id;
        }

        // Data with UserId is searched, if any it is returned, otherwise it throws an error.
        public UserViewModel Handle(){
            var user = _context.Users.Where(i => i.UserId == UserId).SingleOrDefault();
            UserViewModel ViewModel;
            if(user is null)
                throw new InvalidOperationException("There is no customer with this id.");
            else
                ViewModel = _mapper.Map<UserViewModel>(user); // Convert user from User to UserViewModel type
            return ViewModel;       
        }
    }
}
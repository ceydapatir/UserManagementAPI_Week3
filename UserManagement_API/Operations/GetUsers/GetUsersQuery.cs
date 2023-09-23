using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManagement_API.Data.Context;
using UserManagement_API.Data.Entities;
using UserManagement_API.Models.ViewModel;

namespace UserManagement_API.Operations.GetUsers
{
    public class GetUsersQuery
    {
        private readonly IMapper _mapper;
        private readonly UserDBContext _context;
        public GetUsersQuery(UserDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        // Get all users, if there is no user, throw an error
        public List<UserViewModel> Handle(){
            var UserList = _context.Users.OrderBy(i => i.UserId).ToList<User>();
            List<UserViewModel> ViewModelList = new List<UserViewModel>();
            UserViewModel ViewModel;
            if(UserList is null)
                throw new InvalidOperationException("There are no customers.");
            else
                foreach (var user in UserList)
                {
                    ViewModel = _mapper.Map<UserViewModel>(user); // Convert user from User to UserViewModel type
                    ViewModelList.Add(ViewModel);
                }
            return ViewModelList;       
        }
    }
}
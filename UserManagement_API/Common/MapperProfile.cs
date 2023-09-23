using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManagement_API.Data.Entities;
using UserManagement_API.Models.DTO;
using UserManagement_API.Models.ViewModel;

namespace UserManagement_API.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile(){
            CreateMap<User, UserViewModel>()
                .ForMember(i => i.Status, opt => opt.MapFrom(src => ((UserStatusEnum)src.StatusID).ToString()))
                .ForMember(i => i.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyy")));
            CreateMap<UserDTO, User>();
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
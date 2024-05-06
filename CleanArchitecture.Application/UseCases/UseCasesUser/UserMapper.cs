using AutoMapper;
using CleanArchitecture.Application.UseCases.UseCasesUser.CreateUser;
using CleanArchitecture.Application.UseCases.UseCasesUser.DeleteUser;
using CleanArchitecture.Application.UseCases.UseCasesUser.UpdateAllUser;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UseCasesUser
{
    public sealed class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<DeleteUserRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}

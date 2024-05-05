using AutoMapper;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    //Essa classe tem a responsabilidade de configurar o mapeamento entre objetos do tipo CreateUserRequest e
    //User, bem como entre objetos User e CreateUserResponse.

    //Aqui estamos usando o Automapper para simplificar a cópia de dados
    //entre objetos com estruturas diferentes.
    public class CreateUserMapper:Profile
    {
        public CreateUserMapper()
        {
            CreateMap<CreateUserRequest,User>();
            CreateMap<User,CreateUserResponse > ();
        }
    }
}

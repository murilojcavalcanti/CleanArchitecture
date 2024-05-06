using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UseCasesUser.CreateUser
{
    //É um record que representa o comando para criar um novo usuário e contem os dados necessários para criar
    //um usuario, como email e o nome. Implementa a inferface IRequest<CreateUserResponse>, indicando que
    //é um comando que será manipulado pelo MediatR.
    public sealed record CreateUserRequest(string Email, string Name) : IRequest<UserResponse>;
}

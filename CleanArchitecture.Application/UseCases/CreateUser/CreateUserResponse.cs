using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    //é um record que representa a resposta após a criação de um novo usuario e contem as
    //informações relevantes que desejamos retornar após a operação de criação, como o ID, email e nome
    public sealed record CreateUserResponse
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Nome { get; set; }

    }
}

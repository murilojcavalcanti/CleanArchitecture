using CleanArchitecture.Application.UseCases.UseCasesUser.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UseCasesUser
{
    //Usa a biblioteca FluentValidation para definir regras de validação para pbjetos do tipo CreateUserRequest,
    // ou seja essa validação é feita na entrada de dados do Comando.

    //Ela garante que os dados fornecidos para criar um novo usuario atendam aos critérios definidos, como email
    //não vazio, email válido, nome não vazio e tamanho minimo e máximo do nome
    public sealed class UpdateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(User => User.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(User => User.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}

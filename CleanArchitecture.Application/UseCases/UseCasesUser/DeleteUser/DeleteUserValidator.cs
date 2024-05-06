using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UseCasesUser.DeleteUser
{
    public class DeleteUserValidator:AbstractValidator<UserResponse>
    {
        public DeleteUserValidator()
        {
            RuleFor(u=>u.Id).NotEmpty();
        }
    }
}

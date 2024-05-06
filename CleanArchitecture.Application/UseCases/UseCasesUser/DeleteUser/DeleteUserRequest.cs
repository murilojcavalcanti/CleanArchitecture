﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UseCasesUser.DeleteUser
{
    public sealed record DeleteUserRequest(Guid Id) :IRequest<UserResponse>;
}

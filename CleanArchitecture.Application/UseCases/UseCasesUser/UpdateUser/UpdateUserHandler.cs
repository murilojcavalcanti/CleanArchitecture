using AutoMapper;
using CleanArchitecture.Application.UseCases.UseCasesUser.UpdateAllUser;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UseCasesUser.UpdateUser
{
    public sealed class UpdateUserHandler :IRequestHandler<UpdateUserRequest,UserResponse>
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IUserRepository Repository;
        private readonly IMapper Mapper;
        public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository repository, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<UserResponse> Handle(UpdateUserRequest command, CancellationToken cancellationToken)
        {
            var user = await Repository.GetById(command.Id, cancellationToken);
            if (user == null)  return default; 
            user.Name = command.Name;
            user.Email = command.Email;
            Repository.Update(user);

            await UnitOfWork.Commit(cancellationToken);

            return Mapper.Map<UserResponse>(user);
        }
    }
}

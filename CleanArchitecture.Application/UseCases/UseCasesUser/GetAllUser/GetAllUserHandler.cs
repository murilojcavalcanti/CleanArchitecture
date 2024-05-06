using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UseCasesUser.GetAllUser
{
    public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, List<UserResponse>>
    {
        private readonly IUserRepository Repository;
        private readonly IMapper Mapper;

        public GetAllUserHandler(IMapper mapper, IUserRepository repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public async Task<List<UserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            var users = await Repository.GetAll(cancellationToken);
            return Mapper.Map<List<UserResponse>>(users);
        }
    }
}

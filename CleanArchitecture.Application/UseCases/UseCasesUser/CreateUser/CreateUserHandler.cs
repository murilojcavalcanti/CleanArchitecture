using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UseCasesUser.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserResponse>
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IUserRepository UserRepository;
        private readonly IMapper Mapper;

        public CreateUserHandler(IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = Mapper.Map<User>(request);

            UserRepository.Create(user);

            await UnitOfWork.Commit(cancellationToken);

            return Mapper.Map<UserResponse>(user);
        }



    }
}

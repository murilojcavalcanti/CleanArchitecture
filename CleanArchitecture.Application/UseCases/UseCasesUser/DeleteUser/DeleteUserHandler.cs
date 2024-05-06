using AutoMapper;
using CleanArchitecture.Application.UseCases.UseCasesUser.DeleteUser;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UseCasesUser.CreateUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, UserResponse>
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IUserRepository UserRepository;
        private readonly IMapper Mapper;

        public DeleteUserHandler(IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<UserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = Mapper.Map<User>(request);

            UserRepository.Delete(user);

            await UnitOfWork.Commit(cancellationToken);

            return Mapper.Map<UserResponse>(user);
        }



    }
}

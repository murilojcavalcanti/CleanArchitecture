using CleanArchitecture.Application.UseCases.UseCasesUser;
using CleanArchitecture.Application.UseCases.UseCasesUser.CreateUser;
using CleanArchitecture.Application.UseCases.UseCasesUser.DeleteUser;
using CleanArchitecture.Application.UseCases.UseCasesUser.GetAllUser;
using CleanArchitecture.Application.UseCases.UseCasesUser.UpdateAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IMediator Mediator;

        public UsersController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return BadRequest(validatorResult.Errors);

            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllUserRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id) return BadRequest();
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserResponse>> Update(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null ) return BadRequest();
            var deleteUserRequest = new DeleteUserRequest(id.Value);
            var response = await Mediator.Send(deleteUserRequest, cancellationToken);
            return Ok(response);
        }
    }
}

using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuntechIT.Demo.Application.Users.Commands.Create;
using SuntechIT.Demo.Application.Users.Commands.Login;
using SuntechIT.Demo.Application.Users.Queries;
using SuntechIT.Demo.Application.Users.Queries.GetUserById;
using SuntechIT.Demo.Application.Users.Queries.GetUsers;

namespace SuntechIT.Demo.Presentation.Controllers.Customers
{
    [Route("api/v1/users")]
    public class UsersController : ApiController
    {
        public UsersController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        [TranslateResultToActionResult]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<Result<List<UserResponse>>> GetUserById(long? customerId, long? projectId, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery(customerId, projectId);
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("{id}")]
        [TranslateResultToActionResult]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<Result<UserResponse>> GetUserById(string id, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery(id);
            return await _sender.Send(query, cancellationToken);
        }

        [HttpPost]
        [TranslateResultToActionResult]
        public async Task<Result> CreateUser([FromBody] CreateUserRequest model, CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(model.Email, model.Password, model.PhoneNumber, model.Role);
            return await _sender.Send(command, cancellationToken);
        }

        [HttpPost("login")]
        [TranslateResultToActionResult]
        public async Task<Result<string>> Login([FromBody] UserLoginRequest model, CancellationToken cancellationToken)
        {
            var command = new UserLoginCommand(model.Email, model.Password);
            return await _sender.Send(command, cancellationToken);
        }
    }
}

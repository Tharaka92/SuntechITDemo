using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuntechIT.Demo.Application.Users.Create;
using SuntechIT.Demo.Application.Users.Login;

namespace SuntechIT.Demo.Presentation.Controllers.Customers
{
    [Route("api/v1/users")]
    public class UsersController : ApiController
    {
        public UsersController(ISender sender) : base(sender)
        {
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

using Ardalis.Result;
using MediatR;

namespace SuntechIT.Demo.Application.Users.Login
{
    public sealed record UserLoginCommand(string Email, string Password) : IRequest<Result>;
}

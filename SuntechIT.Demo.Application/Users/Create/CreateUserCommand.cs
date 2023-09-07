using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Domain.Enums;

namespace SuntechIT.Demo.Application.Users.Create;

public sealed record CreateUserCommand(string Email,
    string Password,
    string PhoneNumber,
    Role Role) : IRequest<Result>;


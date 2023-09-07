using Ardalis.Result;
using MediatR;

namespace SuntechIT.Demo.Application.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(string UserId) : IRequest<Result<UserResponse>>;
}

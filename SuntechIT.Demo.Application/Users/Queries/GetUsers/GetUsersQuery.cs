using Ardalis.Result;
using MediatR;

namespace SuntechIT.Demo.Application.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery(long? CustomerId, long? ProjectId) : IRequest<Result<List<UserResponse>>>;
}

using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Domain.Repositories;
using SuntechIT.Demo.Shared.Extensions;

namespace SuntechIT.Demo.Application.Users.Queries.GetUsers
{
    internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<List<UserResponse>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = Guard.Against.Null(userRepository);
        }

        public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsers(request.CustomerId, request.ProjectId, cancellationToken);

            if (users.IsNullOrEmpty()) 
            {
                return Result.NotFound();
            }

            var userResponses = users.Select(x => new UserResponse(x.Id, x.Email, x.PhoneNumber)).ToList();

            return new Result<List<UserResponse>>(userResponses);
        }
    }
}

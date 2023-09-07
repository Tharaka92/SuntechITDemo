using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Domain.Repositories;
using SuntechIT.Demo.Shared.Extensions;

namespace SuntechIT.Demo.Application.Users.Queries.GetUserById
{
    internal sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = Guard.Against.Null(userRepository);
        }

        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.UserId.IsNullOrWhiteSpace()) 
            {
                var validationErrorList = new List<ValidationError>()
                {
                    new ValidationError{ ErrorCode = "400", ErrorMessage = "Invalid UserId" }
                };

                return Result<UserResponse>.Invalid(validationErrorList);
            }

            var user = await _userRepository.GetUserById(request.UserId, cancellationToken);

            if (user is null) 
            {
                return Result<UserResponse>.NotFound();
            }

            var response = new UserResponse(user.Id, user.Email, user.PhoneNumber);

            return new Result<UserResponse>(response);
        }
    }
}

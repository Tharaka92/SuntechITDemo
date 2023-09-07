using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SuntechIT.Demo.Application.Users.Create.Validators;

namespace SuntechIT.Demo.Application.Users.Create
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(UserManager<IdentityUser> userManager,
            ILogger<CreateUserCommandHandler> logger)
        {
            _userManager = Guard.Against.Null(userManager);
            _logger = Guard.Against.Null(logger);
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            var userExists = await _userManager.FindByEmailAsync(request.Email);

            if (userExists is not null)
            {
                var validationErrorList = new List<ValidationError>()
                {
                    new ValidationError{ ErrorCode = "400", ErrorMessage = "Email already exists." }
                };

                return Result.Invalid(validationErrorList);
            }

            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Email
            };

            var createResult = await _userManager.CreateAsync(user, request.Password);

            if (!createResult.Succeeded)
            {
                _logger.LogError("Error occurred while creating the new user.");
                return Result.Error("Error occurred while creating the new user.");
            }

            await _userManager.AddToRoleAsync(user, request.Role.ToString());

            return Result.Success();
        }
    }
}

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SuntechIT.Demo.Application.Abstractions;
using SuntechIT.Demo.Application.Users.Create.Validators;
using SuntechIT.Demo.Application.Users.Login.Validators;
using System.Security.Claims;

namespace SuntechIT.Demo.Application.Users.Login
{
    internal sealed class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<string>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public UserLoginCommandHandler(UserManager<IdentityUser> userManager,
             IJwtProvider jwtProvider)
        {
            _userManager = Guard.Against.Null(userManager);
            _jwtProvider = Guard.Against.Null(jwtProvider);
        }

        public async Task<Result<string>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserLoginCommandValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user!, request.Password))
            {
                return Result.Unauthorized();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var jwtToken = _jwtProvider.Generate(user, userRoles.ToList());

            return Result.Success(jwtToken);
        }
    }
}

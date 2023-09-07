using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SuntechIT.Demo.Application.Users.Create.Validators;
using SuntechIT.Demo.Application.Users.Login.Validators;
using System.Security.Claims;

namespace SuntechIT.Demo.Application.Users.Login
{
    internal sealed class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserLoginCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = Guard.Against.Null(userManager);
        }

        public async Task<Result> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserLoginCommandValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}

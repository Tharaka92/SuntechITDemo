using Microsoft.AspNetCore.Identity;

namespace SuntechIT.Demo.Application.Abstractions
{
    public interface IJwtProvider
    {
        string Generate(IdentityUser user);
    }
}

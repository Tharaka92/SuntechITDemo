using Ardalis.GuardClauses;
using Microsoft.Extensions.Options;
using SuntechIT.Demo.Infrastructure.Authentication;

namespace SuntechIT.Demo.OptionsSetup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "JWT";

        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = Guard.Against.Null(configuration);
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}

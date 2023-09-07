using SuntechIT.Demo.Domain.Enums;
using System.Text.Json.Serialization;

namespace SuntechIT.Demo.Application.Users.Login
{
    public class UserLoginRequest
    {
        public string Email { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }

        public string Password { get; set; }
    }
}

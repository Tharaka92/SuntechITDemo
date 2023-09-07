using SuntechIT.Demo.Domain.Enums;
using System.Text.Json.Serialization;

namespace SuntechIT.Demo.Application.Users.Commands.Create
{
    public class CreateUserRequest
    {
        public string Email { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }
}

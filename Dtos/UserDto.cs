using PizzaBE.Enums;
using System.Text.Json.Serialization;

namespace PizzaBE.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ERoles Role { get; set; } = ERoles.CUSTOMER;
    }
}

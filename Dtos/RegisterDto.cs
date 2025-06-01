using PizzaBE.Enums;

namespace PizzaBE.Dtos
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ERoles Role { get; set; } = ERoles.CUSTOMER;
    }
}

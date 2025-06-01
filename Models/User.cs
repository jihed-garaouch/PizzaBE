using Microsoft.AspNetCore.Identity;
using PizzaBE.Enums;

namespace PizzaBE.Models
{
    public class User: IdentityUser
    {
        public ERoles Role { get; set; } = ERoles.CUSTOMER;
    }
}

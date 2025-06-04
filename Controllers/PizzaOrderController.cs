using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaBE.Models;
using PizzaBE.Services;

namespace PizzaBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaOrderController: ControllerBase
    {
        private readonly IPizzaOrderService _pizzaOrderService;
        private readonly UserManager<User> _userManager;

        public PizzaOrderController(IPizzaOrderService pizzaOrderService, UserManager<User> userManager)
        {
            _pizzaOrderService = pizzaOrderService;
            _userManager = userManager;
        }

       
        [HttpGet()]
        public async Task<IActionResult> GetMyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var orders = await _pizzaOrderService.GetAllByUserIdAsync(user.Id);
            return Ok(orders);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] PizzaOrder order)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            order.UserId = user.Id;
            order.User = user;
            order.OrderTime = DateTime.UtcNow;
            await _pizzaOrderService.CreateOrderAsync(order);
            return Ok("Order placed successfully");
        }
    }
}

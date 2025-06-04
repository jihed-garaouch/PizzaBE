using PizzaBE.Models;

namespace PizzaBE.Services
{
    public interface IPizzaOrderService
    {
        Task<List<PizzaOrder>> GetAllByUserIdAsync(string userId);
        Task CreateOrderAsync(PizzaOrder order);
        Task UpdateOrderAsync(PizzaOrder order);
        Task DeleteOrderAsync(string id);
    }
}

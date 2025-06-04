using PizzaBE.Models;
using PizzaBE.Repository;

namespace PizzaBE.Services.Impl
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private readonly IPizzaOrderRepository _orderRepository;

        public PizzaOrderService(IPizzaOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<PizzaOrder>> GetAllByUserIdAsync(string userId)
        {
            return await _orderRepository.GetAllAsyncByUserId(userId);
        }

        public async Task CreateOrderAsync(PizzaOrder order)
        {
            // Optional: add business rules here
            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(PizzaOrder order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(string id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}

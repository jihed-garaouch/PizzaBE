using PizzaBE.Models;

namespace PizzaBE.Repository
{
    public interface IPizzaOrderRepository
    {
        Task<List<PizzaOrder>> GetAllAsyncByUserId(string userId);
     
        Task AddAsync(PizzaOrder order);
        Task UpdateAsync(PizzaOrder order);
        Task DeleteAsync(string id);
    }
}

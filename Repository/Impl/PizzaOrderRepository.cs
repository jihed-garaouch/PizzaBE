using Microsoft.EntityFrameworkCore;
using PizzaBE.Models;

namespace PizzaBE.Repository.Impl
{
    public class PizzaOrderRepository : IPizzaOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public PizzaOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       

        public async Task AddAsync(PizzaOrder order)
        {
            await _context.PizzaOrders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PizzaOrder order)
        {
            _context.PizzaOrders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var order = await _context.PizzaOrders.FindAsync(id);
            if (order != null)
            {
                _context.PizzaOrders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PizzaOrder>> GetAllAsyncByUserId(string userId)
        {

            return await _context.PizzaOrders
                .Include(o => o.Items)
                .Include(o => o.TrackingSteps)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }
    }
}

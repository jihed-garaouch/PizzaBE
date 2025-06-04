using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PizzaBE.Models
{
   
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<PizzaItem> PizzaItems { get; set; }
        public DbSet<TrackingStep> TrackingSteps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }

}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaBE.Models
{
    public class PizzaItem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Label { get; set; } 

        public decimal Price { get; set; }

        [ForeignKey("PizzaOrder")]
        public string PizzaOrderId { get; set; }
        public PizzaOrder PizzaOrder { get; set; }
    }
}

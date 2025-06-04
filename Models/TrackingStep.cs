using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaBE.Models
{
    public class TrackingStep
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public string? Timestamp { get; set; }

        public bool Completed { get; set; }

        [ForeignKey("PizzaOrder")]
        public string PizzaOrderId { get; set; }
        public PizzaOrder PizzaOrder { get; set; }
    }
}

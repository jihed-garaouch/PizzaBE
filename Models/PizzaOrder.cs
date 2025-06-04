using System.ComponentModel.DataAnnotations;

namespace PizzaBE.Models
{
    public class PizzaOrder
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Status { get; set; } 

        [Required]
        public string DeliveryType { get; set; } 
        public string? Address { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        public DateTime EstimatedTime { get; set; }

        public decimal Total { get; set; }

        public string? SpecialInstructions { get; set; }

        public required string UserId { get; set; }

        public User? User { get; set; }


        public List<PizzaItem> Items { get; set; } = new();
        public List<TrackingStep> TrackingSteps { get; set; } = new();
    }
}

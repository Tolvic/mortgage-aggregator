using System.ComponentModel.DataAnnotations;

namespace mortageAggregator.UI.Models
{
    public class AvailableMortageRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public decimal PropertyValue { get; set; }

        [Required]
        public decimal DepositAmount { get; set; }
    }
}

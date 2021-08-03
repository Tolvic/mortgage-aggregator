using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mortageAggregator.API.Models
{
    public class Mortgage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Lender { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal interestRate { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal MaxLoandToValue { get; set; }

    }
}

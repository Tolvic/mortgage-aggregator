using System;
using System.ComponentModel.DataAnnotations;

namespace mortageAggregator.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }

        public int GetAge()
        {
            return new DateTime(DateTime.Now.Subtract(DateOfBirth).Ticks).Year;
        }
    }
}

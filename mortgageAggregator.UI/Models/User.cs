using System;
using System.ComponentModel.DataAnnotations;

namespace mortageAggregator.UI.Models
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class FireReport : Entity
    {
        [Required]
        public string Location { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? ExtraInstructions { get; set; }

        public int EmergencyType { get; set; }

        public DateTime Date { get; set; }
    }
}

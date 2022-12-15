using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Postulation : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        public DateTime Date { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Release : Entity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }
    }
}

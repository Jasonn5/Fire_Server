using System.ComponentModel.DataAnnotations;

namespace Authentication.Entities
{
    public class Role
    {
        [Key]
        public string Name { get; set; }
    }
}

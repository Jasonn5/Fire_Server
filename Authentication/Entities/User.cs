using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [NotMapped]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }


        [NotMapped]
        public string Token { get; set; }

        [NotMapped]
        public ICollection<Role> Roles { get; set; }
    }
}

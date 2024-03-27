using System.ComponentModel.DataAnnotations;

namespace YappaDevChallenge.Model
{
    public class Client
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Debe ingresar un nombre")]
        public string Nombres { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Debe ingresar un apellido")]
        public string Apellidos { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "El CUIL debe tener un máximo de 20 caracteres.")]
        public string CUIT { get; set; }
        [StringLength(50)]
        public string? Domicilio { get; set; }
        [Required]
        [StringLength(20)]
        public string? TelefonoCelular { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }

}

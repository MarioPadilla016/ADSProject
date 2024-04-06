using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Profesor
    {
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracateres.")]
        public string NombresProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracateres.")]
        public string ApellidosProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser mayor a 254 caracateres.")]
        public string EmailProfesor { get; set; }
    }
}

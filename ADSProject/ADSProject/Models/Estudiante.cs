using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdEstudiante))]
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracateres.")]
        public string NombresEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracateres.")]
        public string ApellidosEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MinLength(length: 12, ErrorMessage = "La longitud del campo no puede ser menor a 50 caracateres.")]
        [MaxLength(length: 12, ErrorMessage = "La longitud del campo no puede ser mayor a 12 caracateres.")]
        public string CodigoEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser mayor a 254 caracateres.")]
        [EmailAddress(ErrorMessage = "El formato del correo electronico no es valido.")]
        public string CorreoEstudiante { get; set; }
    }
}
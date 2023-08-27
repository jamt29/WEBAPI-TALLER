using System.ComponentModel.DataAnnotations;

namespace Ejercicio_26_07.DTO
{
    public class TallerCreacionDTO
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(maximumLength: 30)]
        [SinNumeros]
        public string Nombre { get; set; }

    }
}

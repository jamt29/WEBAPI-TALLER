using System.ComponentModel.DataAnnotations;

namespace Ejercicio_26_07.DTO
{
    public class AutoCreacionDTO
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(maximumLength: 15)]
        [SinNumeros]

        public string Marca { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(maximumLength: 15)]
        public string Modelo { get; set; }

        public int Km { get; set; }


        public List<int> TalleresIDs { get; set; }

       
    }
}

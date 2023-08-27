using System.ComponentModel.DataAnnotations;

namespace Ejercicio_26_07.Entidades
{
    public class Taller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [StringLength(maximumLength: 30)]
        [SinNumeros]
        public string Nombre { get; set; }
        public List<TallerAuto> TalleresAutos { get; set; }
    }
}

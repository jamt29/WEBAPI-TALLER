using System.ComponentModel.DataAnnotations;

namespace Ejercicio_26_07.Entidades
{
    public class Auto
    {
        public int Id{ get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [SinNumeros]
        public string Marca{ get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Modelo{ get; set; }
        
        public int Km{ get; set; }

        public List<TallerAuto> TalleresAutos { get; set; }
    }
}

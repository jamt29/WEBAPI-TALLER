namespace Ejercicio_26_07.Entidades
{
    public class TallerAuto
    {
        public int AutoId { get; set; }
        public int TallerId { get; set; }
        public  Auto Auto { get; set; }
        public  Taller Taller { get; set; }


    }
}

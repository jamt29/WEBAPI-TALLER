using AutoMapper;
using Ejercicio_26_07.DTO;
using Ejercicio_26_07.Entidades;

namespace Ejercicio_26_07
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            // Mapeo de Auto a AutoDTO
            CreateMap<Auto, AutoDTO>();

            // Mapeo de AutoCreacionDTO a Auto, con personalización para mapear TalleresAutos
            CreateMap<AutoCreacionDTO, Auto>()
                .ForMember(auto => auto.TalleresAutos, opc => opc.MapFrom(MapTallerAuto));

            // Mapeo de Taller a TallerDTO
            CreateMap<Taller, TallerDTO>();

            // Mapeo de TallerCreacionDTO a Taller
            CreateMap<TallerCreacionDTO, Taller>();
        }


        // Este método personalizado se utiliza para mapear la propiedad "TalleresIDs" de AutoCreacionDTO a la colección "TalleresAutos" en la entidad Auto.
        private List<TallerAuto> MapTallerAuto(AutoCreacionDTO dTO, Auto auto)
        {
            // Crear una nueva lista para almacenar las relaciones TallerAuto
            var listaTallerAuto = new List<TallerAuto>();

            // Verificar si la lista de TalleresIDs en el DTO es nula
            if (dTO.TalleresIDs == null)
                return listaTallerAuto;  // Si es nula, devolver la lista vacía

            // Recorrer cada ID de taller en la lista de TalleresIDs del DTO
            foreach (var item in dTO.TalleresIDs)
            {
                // Crear una nueva instancia de TallerAuto y asignar el ID del taller
                listaTallerAuto.Add(new TallerAuto() { TallerId = item });
            }

            // Devolver la lista de relaciones TallerAuto
            return listaTallerAuto;
        }
    }
}

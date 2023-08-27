using AutoMapper;
using Ejercicio_26_07.DTO;
using Ejercicio_26_07.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio_26_07.Controllers
{
    [ApiController]
    [Route("api/auto")]
    public class AutoController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AutoController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutoDTO>>> Get()
        {
            // Obtener todos los autos de la base de datos
            var autos = await _context.Autos.ToListAsync();

            // Mapear los autos a DTOs y devolverlos
            return _mapper.Map<List<AutoDTO>>(autos);
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<AutoDTO>> Get(int id)
        {
            // Buscar un auto por su ID
            var auto = await _context.Autos.FirstOrDefaultAsync(a => a.Id == id);

            if (auto == null)
                return NotFound("No se encontró ningún auto con ese ID");

            // Devolver el auto encontrado en formato DTO
            return _mapper.Map<AutoDTO>(auto);
        }



        [HttpGet("{word}")]
        public async Task<ActionResult<IEnumerable<AutoDTO>>> Get(string word)
        {
            // Buscar autos que contengan la palabra en su marca o modelo
            var autos = await _context.Autos.Where(a => (a.Marca + a.Modelo).Contains(word)).ToListAsync();

            if (autos == null)
                return NotFound();

            // Devolver los autos encontrados en formato DTO
            return _mapper.Map<List<AutoDTO>>(autos);
        }



        [HttpPost]
        public async Task<IActionResult> Post(AutoCreacionDTO autoCreacionDTO)
        {
            // Verificar si los IDs de talleres proporcionados son válidos
            var talleresIDs = await _context.Talleres
                                            .Where(taller => autoCreacionDTO.TalleresIDs.Contains(taller.Id))
                                            .Select(x => x.Id)
                                            .ToListAsync();

            if (autoCreacionDTO.TalleresIDs.Count() != talleresIDs.Count())
                return BadRequest("Uno o varios de los IDs de los talleres no fueron encontrados");

            // Mapear el DTO de creación a un objeto Auto
            var auto = _mapper.Map<Auto>(autoCreacionDTO);

            // Agregar el auto a la base de datos y guardar cambios
            await _context.Autos.AddAsync(auto);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(AutoCreacionDTO autoDTO, int id)
        {
            // Verificar si el auto existe por su ID
            var exist = await _context.Autos.AnyAsync(a => a.Id == id);

            if (!exist)
                return NotFound();

            // Mapear el DTO de creación a un objeto Auto
            var auto = _mapper.Map<Auto>(autoDTO);

            auto.Id = id;

            // Actualizar el auto en la base de datos y guardar cambios
            _context.Update(auto);
            await _context.SaveChangesAsync();

            return Ok();
        }





        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Verificar si el auto existe por su ID
            var exist = await _context.Autos.AnyAsync(a => a.Id == id);

            if (!exist)
                return NotFound();

            // Crear un objeto Auto con el ID y eliminarlo de la base de datos
            var auto = new Auto() { Id = id };
            _context.Remove(auto);

            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}

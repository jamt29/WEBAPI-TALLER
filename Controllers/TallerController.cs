using AutoMapper;
using Ejercicio_26_07.DTO;
using Ejercicio_26_07.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio_26_07.Controllers
{
    [ApiController]
    [Route("api/taller")]
    public class TallerController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public TallerController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TallerDTO>>> Get()
        {
            // Obtener todos los talleres de la base de datos
            var talleres = await _context.Talleres.ToListAsync();

            // Mapear los talleres a DTOs y devolverlos
            return _mapper.Map<List<TallerDTO>>(talleres);
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<TallerDTO>> Get(int id)
        {
            // Buscar un taller por su ID
            var taller = await _context.Talleres.FirstOrDefaultAsync(t => t.Id == id);

            if (taller == null)
                return NotFound("No se encontró un registro con ese ID");

            // Devolver el taller encontrado en formato DTO
            return _mapper.Map<TallerDTO>(taller);
        }



        [HttpGet("{word}")]
        public async Task<ActionResult<IEnumerable<TallerDTO>>> Get(string word)
        {
            // Buscar talleres que contengan la palabra en su nombre
            var taller = await _context.Talleres.Where(n => n.Nombre.Contains(word)).ToListAsync();

            if (taller == null)
                return NotFound();

            // Devolver los talleres encontrados en formato DTO
            return _mapper.Map<List<TallerDTO>>(taller);
        }



        [HttpPost]
        public async Task<IActionResult> Post(TallerCreacionDTO tallerCreacionDTO)
        {
            // Mapear el DTO de creación a un objeto Taller
            var taller = _mapper.Map<Taller>(tallerCreacionDTO);

            // Agregar el taller a la base de datos y guardar cambios
            await _context.Talleres.AddAsync(taller);
            await _context.SaveChangesAsync();

            return Ok();
        }



        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(TallerCreacionDTO tallerDTO, int id)
        {
            // Verificar si el taller existe por su ID
            var exist = await _context.Talleres.AnyAsync(t => t.Id == id);

            if (!exist)
                return NotFound();

            // Mapear el DTO de creación a un objeto Taller
            var taller = _mapper.Map<Taller>(tallerDTO);
            taller.Id = id;

            // Actualizar el taller en la base de datos y guardar cambios
            _context.Update(taller);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Verificar si el taller existe por su ID
            var exist = await _context.Talleres.AnyAsync(t => t.Id == id);

            if (!exist)
                return NotFound();

            // Crear un objeto Taller con el ID y eliminarlo de la base de datos
            var taller = new Taller() { Id = id };
            _context.Remove(taller);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}

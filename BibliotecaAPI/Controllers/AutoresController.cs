using BibliotecaAPI.Data;
using BibliotecaAPI.Enitities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly ILogger<AutoresController> logger;

        public AutoresController(ApplicationDBContext context, ILogger<AutoresController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        

        [HttpGet("/listado-de-autores")]
        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            //Ejemplo
            logger.LogTrace("Obteniendo el listado de Autores");
            logger.LogDebug("Obteniendo el listado de Autores");
            logger.LogInformation("Obteniendo el listado de Autores");
            logger.LogWarning("Obteniendo el listado de Autores");
            logger.LogError("Obteniendo el listado de Autores");
            logger.LogCritical("obteniendo el listado de Autores");
            return await context.Autores.ToListAsync();
        }

        [HttpGet("primero")] //api/autores/promero
        public async Task<Autor> GetPrimerAutor()
        {
            return await context.Autores.FirstAsync();
        }

        [HttpGet("{id:int}")] // cuando tiene un parametro {id:int} esto son parametros de ruta.
        public async Task<ActionResult<Autor>> Get(int id){
            var autor = await context.Autores
                .Include(x => x.Libros)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(autor is null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpGet("{Nombre:alpha}")]
        public async Task<IEnumerable<Autor>> GetAutorNombre(string nombre)
        {
            return await context.Autores.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Autor autor)
        {
            if(id != autor.Id)
            {
                return BadRequest("Los ids deben coincicir");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var registrosBorrados = await context.Autores.Where(x => x.Id == id).ExecuteDeleteAsync();
            if(registrosBorrados == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;
using YappaDevChallenge.Context;
using YappaDevChallenge.Model;

namespace YappaDevChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Documentación
        [HttpGet("documentation")]
        public ActionResult<object> GetDocumentation()
        {
            var documentation = new
            {
                Title = "API de Clientes",
                Description = "Esta API permite realizar operaciones CRUD en una lista de clientes.",
                Detalles = new List<object>
                {
                    new { Description = "Esta api se encarga de insertar, actualizar, filtrar y  traer todos los clientes en la base de datos local" },
                    new { Inicializacion = "Si se desea implementar la BD propia para probar el proyecto, se debe ejecutar la migración (add-migration) y posteriormente (update-database)" },
                    new { Propiedad = "Creado por Joel Garbagnate, como Challengue para Yappa Dev" },
                }
            };

            return Ok(documentation);
        }

        // GET: api/Clientes    (Obtiene todos los clientes)
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/id  (Obtiene un cliente por su ID especifica, obviamente va a ser unica)
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: api/Clientes/string   (Trae todos los clientes con el nombre que contenga el string ingresado)
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Client>>> Search(string name)
        {
            return await _context.Clientes
                .Where(c => c.Nombres.Contains(name) || c.Apellidos.Contains(name))
                .ToListAsync();
        }

        // POST: api/Clientes   (Crea un nuevo cliente)
        [HttpPost("Insert")]
        public async Task<ActionResult<Client>> Insert(Client cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = cliente.ID }, cliente);
            }
            catch (Exception ex)
            {
                Log.Error($"Error al insertar el cliente: {ex.Message}", ex);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // PUT: api/Update/id     (Actualiza un cliente según la Id suministrada)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client cliente)
        {
            if (id != cliente.ID)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clientes.Any(e => e.ID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
    }
}

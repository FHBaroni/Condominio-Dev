using CondominioDev.Api.Data;
using CondominioDev.Api.DTO;
using CondominioDev.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CondominioDev.Api.Controllers
{
    [ApiController]
    [Route("api/habitantes")]
    public class HabitantesController : ControllerBase
    {
        private readonly ProjetoDbContext _context;

        public HabitantesController(ProjetoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Habitante>> Get()
        {
            return Ok(_context.Habitante.ToList().OrderBy(h => h.Nome));
        }

        [HttpGet("{id}")]
        public ActionResult<List<Habitante>> GetById([FromRoute] int id)
        {
            return Ok(_context.Habitante.Find(id));
        }


        [HttpPost]
        public ActionResult<Habitante> Post(
        [FromBody] HabitantesDTO body
        )
        {
  
            if (_context.Habitante.Any(h => h.CPF == body.CPF))
            {
                return BadRequest("CPF já cadastrado");
            }
            var novohabitante = new Habitante
            {
                Nome = body.Nome,
                Sobrenome = body.Sobrenome,
                DataNascimento = body.DataNascimento,
                Renda = body.Renda,
                CPF = body.CPF,
                CondominioId = 1,
                CustoCondominio = 350
            };


            _context.Habitante.Add(novohabitante);

            _context.SaveChanges();

            return Created("api/habitantes", novohabitante);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var habitante = _context.Habitante.Find(id);

            if (habitante == null) return NotFound();

            _context.Habitante.Remove(habitante);

            _context.SaveChanges();

            return NoContent();
        }
    }
}

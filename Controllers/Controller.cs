using CondominioDev.Api.Data;
using CondominioDev.Api.DTO;
using CondominioDev.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CondominioDev.Api.Controllers
{
    [ApiController]
    [Route("api/Habitantes")]
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
            return Ok(_context.Habitante.ToList());
        }

        [HttpPost]
        public ActionResult<Habitante> Post(
            [FromBody] HabitantesDTO body
        )
        {
            var novohabitante = new Habitante
            {
                Nome = body.Nome,
                Sobrenome = body.Sobrenome,
                DataNacimento = body.DataNacimento,
                Renda = body.Renda,
                CPF = body.CPF
            };
            _context.Add(novohabitante);
            _context.SaveChanges();
            return Ok();

        }
    }
}
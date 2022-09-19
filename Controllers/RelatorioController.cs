using CondominioDev.Api.Data;
using CondominioDev.Api.DTO;
using CondominioDev.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CondominioDev.Api.Controllers
{
    [ApiController]
    [Route("api/Relatorios")]
    public class RelatorioController : ControllerBase
    {
        private readonly ProjetoDbContext _context;

        public RelatorioController(ProjetoDbContext context)
        {
            _context = context;
        }


        [HttpGet("Relatório")]
        public ActionResult<List<CondominioDTO>> Get()



        {
            var query = _context.Condominio;
            return Ok(query);

        }


    }
}

//[HttpGet("Relatório do condomínio")]
//public ActionResult<Condominio> GetRelatorio()
////[FromBody] CondominioDTO body)
//{
//    //var query = _context;
//    //query.Include(c => c.GastoTotal);
//    //query = query.OrderBy(x => x.Id);
//    return Ok(_context.Condominio.ToList());

//}

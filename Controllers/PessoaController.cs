using System.Threading.Tasks;
using API_ASP.NET_Core_Course.Data;
using Microsoft.AspNetCore.Mvc; // Responsavel pela criação das rotas
using Microsoft.EntityFrameworkCore;
using API_ASP.NET_Core_Course.Models;

namespace API_ASP.NET_Core_Course.Controllers
{
    [ApiController]
    [Route("[controller]")] // [controller] será substituido pelo nome da model
    public class PessoaController(DataContext context) : ControllerBase
    {
        private DataContext dc = context;

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Pessoa pessoa)
        {
            dc.Pessoa.Add(pessoa);
            await dc.SaveChangesAsync();

            return Created("Objeto pessoa", pessoa);
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await dc.Pessoa.ToListAsync();

            return Ok(dados);
        }

        [HttpGet("api/{id}")]
        public Pessoa porId(int id)
        {
            Pessoa? pessoa = dc.Pessoa.Find(id);

            return pessoa;
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Pessoa pessoa)
        {
            try
            {
                dc.Pessoa.Update(pessoa);
                await dc.SaveChangesAsync();

                return Ok(pessoa);
            }
            catch (DbUpdateException)
            {
                throw;
            }

        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> deletar(int id)
        {
            Pessoa pessoa = porId(id);

            if (pessoa == null) return NotFound();

            dc.Pessoa.Remove(pessoa);
            await dc.SaveChangesAsync();

            return Ok();
        }
    }
}
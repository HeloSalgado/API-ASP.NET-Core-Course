using API_ASP.NET_Core_Course.Dto;
using API_ASP.NET_Core_Course.Models;
using API_ASP.NET_Core_Course.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ASP.NET_Core_Course.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController(TarefaService service) : ControllerBase
    {
        private readonly TarefaService tarefaService = service;

        [HttpPost]
        public ActionResult Cadastrar([FromBody] TarefaDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados da tarefa não podem ser nulos.");
            }

            try
            {

                var tarefa = new Tarefa
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    IsCompleted = dto.IsCompleted,
                    DueDate = dto.DueDate,
                    CreatedAt = DateTime.Now
                };

                var tarefaCriada = tarefaService.Create(tarefa);

                var uri = Url.Action(nameof(PorId), new { id = tarefa.Id });

                return Created(uri, tarefaCriada);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Ocorreu um erro ao criar a tarefa.");
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> Listar()
        {
            try
            {
                var dados = tarefaService.GetAll();
                return Ok(dados);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao listar as tarefas.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Tarefa> PorId(int id)
        {
            try
            {
                var tarefa = tarefaService.GetById(id);

                if (tarefa == null)
                {
                    return NotFound();
                }

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao buscar a tarefa.");
            }
        }

        [HttpPut]
        public ActionResult<Tarefa> Editar([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest("Dados da tarefa não podem ser nulos.");
            }

            try
            {
                var tarefaExistente = tarefaService.GetById(tarefa.Id);

                if (tarefaExistente == null)
                {
                    return NotFound();
                }

                tarefa.CreatedAt = tarefaExistente.CreatedAt;

                tarefaService.Update(tarefa);

                return Ok(tarefa);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao editar a tarefa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro inesperado.");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                var tarefa = tarefaService.GetById(id);

                if (tarefa == null)
                {
                    return NotFound();
                }

                tarefaService.Delete(tarefa);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao deletar a tarefa.");
            }
        }
    }
}
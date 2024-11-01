using API_ASP.NET_Core_Course.Data;
using API_ASP.NET_Core_Course.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ASP.NET_Core_Course.Service
{
    public class TarefaService(DataContext context)
    {
        private readonly DataContext dc = context;

        public Tarefa? GetById(int id)
        {
            return dc.Tarefa
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);
        }

        public List<Tarefa> GetAll()
        {
            return dc.Tarefa.ToList();
        }
        public Tarefa Create(Tarefa tarefa)
        {
            dc.Tarefa.Add(tarefa);
            dc.SaveChanges();
            return tarefa;
        }

        public Tarefa Update(Tarefa tarefa)
        {
            dc.Tarefa.Update(tarefa);
            dc.SaveChanges();
            return tarefa;
        }

        public void Delete(Tarefa tarefa)
        {
            dc.Tarefa.Remove(tarefa);
            dc.SaveChanges();
        }
    }
}
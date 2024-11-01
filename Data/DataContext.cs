using API_ASP.NET_Core_Course.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ASP.NET_Core_Course.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Tarefa> Tarefa { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

    }
}
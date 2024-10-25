using API_ASP.NET_Core_Course.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ASP.NET_Core_Course.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
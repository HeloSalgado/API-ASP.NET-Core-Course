using API_ASP.NET_Core_Course.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        var stringDeConexao = "Server=localhost;Database=api_tarefas;User=root;Password=25101724;";
        optionsBuilder.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao));

        return new DataContext(optionsBuilder.Options);
    }
}

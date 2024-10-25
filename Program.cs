using API_ASP.NET_Core_Course.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços (substitui o ConfigureServices)
builder.Services.AddControllers();
string stringDeConexao = builder.Configuration.GetConnectionString("conexaoMySQL");
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao)));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
});

var app = builder.Build();

// Configuração do pipeline de requisição (substitui o Configure)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

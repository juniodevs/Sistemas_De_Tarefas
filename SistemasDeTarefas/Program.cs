using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Repositorios;
using SistemasDeTarefas.Repositorios.Interfaces;

namespace SistemasDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string mySqlConnectionStr = builder.Configuration.GetConnectionString("DataBase");

            builder.Services.AddDbContextPool<SistemaTarefasDBContex>
                (options => options.UseMySql(mySqlConnectionStr,
                ServerVersion.AutoDetect(mySqlConnectionStr)));

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
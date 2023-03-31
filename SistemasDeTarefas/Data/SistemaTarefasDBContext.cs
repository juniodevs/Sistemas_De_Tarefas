using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions
            <SistemaTarefasDBContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}

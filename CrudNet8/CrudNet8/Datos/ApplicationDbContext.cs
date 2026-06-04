using CrudNet8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace CrudNet8.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //Agregar los modelos aquí (Cada modelo corresponde a una tabla en la BD)
        public DbSet<PersonaM> Persona { get; set; }  
        public DbSet<RolM> Rol { get; set; }
        public DbSet<ContactoM> Contactos { get; set; }
        public DbSet<UsuarioM> Usuarios { get; set; }
        public DbSet<CategoriaM> Categoria { get; set; }
        public DbSet<EvaluacionesM> Evaluaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // siempre recomendable
            modelBuilder.Entity<CategoriaM>().ToTable("categoria"); // <--- aquí dentro de la clase
        }
    }
}

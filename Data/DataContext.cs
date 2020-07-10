using lxwebapijwt.Models;
using Microsoft.EntityFrameworkCore;

namespace lxwebapijwt.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        :base(options)
        {
            // this.OnConfiguring()
        }

        public DbSet<Local> Locais { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            
        }


    }
}
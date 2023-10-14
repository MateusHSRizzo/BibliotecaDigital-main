using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> op): base(op){}

        public DbSet<Editora> Editora { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Livro> Livro { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Blog_do_Matoso.Models
{
    public class DBcontext : DbContext
    {

        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {
            //esse metodo aqui executa a criação de Migrações, usando o Entity Framework
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //cria um contexto para as tabelas 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Depoimentos>().HasKey(t => t.Id);
        }

        public DbSet<Depoimentos> Depoimentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


    }
}

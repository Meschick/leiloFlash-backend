using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Data
{
    public class LeiloDbContext: DbContext
    {

        public LeiloDbContext(DbContextOptions<LeiloDbContext> options) : base(options) { }



        // Tabelas do banco de dados
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<LeilaoModel> Leiloes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnderecoModel>().ToTable("Endereco");

            modelBuilder.Entity<UsuarioModel>()
                .ToTable("Usuario")
                .Property(u => u.Tipo)
                .HasConversion<string>();

            modelBuilder.Entity<UsuarioModel>()
               .ToTable("Usuario")
               .Property(u => u.StatusUsuario)
               .HasConversion<string>();

            modelBuilder.Entity<LeilaoModel>()
                .ToTable("Leilao")
                .Property(l => l.StatusLeilao)
                .HasConversion<string>();
        }

    }
}

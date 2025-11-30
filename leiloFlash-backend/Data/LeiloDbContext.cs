using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Data
{
    public class LeiloDbContext: DbContext
    {

        public LeiloDbContext(DbContextOptions<LeiloDbContext> options) : base(options) { }

        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<LeilaoModel> Leiloes { get; set; }
        public DbSet<VeiculoModel> Veiculo { get; set; }
        public DbSet<LoteModel> Lote { get; set; }
        public DbSet<ImagemModel> Imagem { get; set; }
        public DbSet<LanceModel> Lance { get; set; }



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

            modelBuilder.Entity<VeiculoModel>().ToTable("Veiculo");

            modelBuilder.Entity<LoteModel>().ToTable("Lote");

            modelBuilder.Entity<ImagemModel>().ToTable("Imagem");
            modelBuilder.Entity<LanceModel>().ToTable("Lance");
        }

    }
}

using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Data
{
    public class LeiloDbContext: DbContext
    {

        public LeiloDbContext(DbContextOptions<LeiloDbContext> options) : base(options) { }



        // Tabelas do banco de dados
        public DbSet<CompradorModel> Compradores { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompradorModel>().ToTable("Comprador");
            modelBuilder.Entity<EnderecoModel>().ToTable("Endereco");
            modelBuilder.Entity<UsuarioModel>().ToTable("Usuario");
        }

    }
}

using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Data
{
    public class LeiloDbContext: DbContext
    {

        public LeiloDbContext(DbContextOptions<LeiloDbContext> options) : base(options) { }



        // Tabelas do banco de dados
        DbSet<CompradorModel> Compradores { get; set; }
        DbSet<EnderecoModel> Enderecos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompradorModel>().ToTable("Comprador");
            modelBuilder.Entity<EnderecoModel>().ToTable("Endereco");
        }

    }
}

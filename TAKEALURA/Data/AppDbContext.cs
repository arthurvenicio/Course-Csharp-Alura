using Microsoft.EntityFrameworkCore;
using TAKEALURA.Models;

namespace TAKEALURA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
            
            modelBuilder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId);

            modelBuilder.Entity<Sessao>()
                .HasOne(s => s.Filme)
                .WithMany(f => f.Sessoes)
                .HasForeignKey(s => s.FilmeId);
            modelBuilder.Entity<Sessao>()
                .HasOne(s => s.Cinema)
                .WithMany(c => c.Sessoes)
                .HasForeignKey(s => s.CinemaId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
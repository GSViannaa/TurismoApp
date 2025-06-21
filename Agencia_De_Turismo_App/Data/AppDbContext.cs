using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using TurismoApp.Domain.models;

namespace Agencia_De_Turismo_App.Data
{
    public class IdentidadeContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public IdentidadeContext(DbContextOptions<IdentidadeContext> options) : base(options) { }

    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PaisDestino> PaisesDestino { get; set; }
        public DbSet<CidadeDestino> CidadeDestino { get; set; }
        public DbSet<PontoTuristico> PontosTuristicos { get; set; }
        public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }
        public DbSet<Reservas> Reservas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<PaisDestino>().ToTable("PaisDestino");
            modelBuilder.Entity<CidadeDestino>().ToTable("CidadeDestino");
            modelBuilder.Entity<PontoTuristico>().ToTable("PontoTuristico");
            modelBuilder.Entity<PacoteTuristico>().ToTable("PacoteTuristico");
            modelBuilder.Entity<Reservas>().ToTable("Reserva");

            // 1:N - País > Cidades
            modelBuilder.Entity<CidadeDestino>()
                .HasOne(c => c.PaisDestino)
                .WithMany(p => p.Cidades)
                .HasForeignKey(c => c.PaisDestinoId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N - Cidade > Pontos Turísticos
            modelBuilder.Entity<PontoTuristico>()
                .HasOne<CidadeDestino>()
                .WithMany(c => c.PontosTuristicos)
                .HasForeignKey(p => p.CidadeDestinoId);

            // 1:N - Cliente > Reservas
            modelBuilder.Entity<Reservas>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reserva)
                .HasForeignKey(r => r.ClienteId);

            // 1:N - Pacote > Reservas
            modelBuilder.Entity<Reservas>()
                .HasOne(r => r.PacoteTuristico)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.PacoteTuristicoId);

            // N:N - Pacote <> Cidade 
            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(p => p.Cidades)
                .WithMany(c => c.Pacotes);

        }
    }
}

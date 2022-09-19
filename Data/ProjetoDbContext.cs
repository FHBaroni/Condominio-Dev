using CondominioDev.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioDev.Api.Data
{
    public class ProjetoDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ProjetoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Habitante> Habitante { get; set; }
        public DbSet<Condominio> Condominio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CONEXAO_SQL"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Habitante
            modelBuilder.Entity<Habitante>()
                .ToTable("Habitantes");

            modelBuilder.Entity<Habitante>()
                .HasKey(h => h.Id);

            modelBuilder.Entity<Habitante>()
               .Property(h => h.Nome)
               .HasColumnType("varchar")
               .HasMaxLength(200)
               .IsRequired();

            modelBuilder.Entity<Habitante>()
                .Property(h => h.Sobrenome)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            modelBuilder.Entity<Habitante>()
                .Property(h => h.DataNascimento)
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<Habitante>()
                .Property(h => h.Renda)
                .HasColumnType("float")
                .IsRequired();

            modelBuilder.Entity<Habitante>()
                .Property(h => h.CPF)
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Habitante>()
                .Property(h => h.CustoCondominio)
                .HasColumnType("float")
                .IsRequired();

            modelBuilder.Entity<Habitante>()
                   .HasOne<Condominio>(habitante => habitante.Condominio)
                   .WithMany(condominio => condominio.Habitante)
                   .HasForeignKey(habitante => habitante.CondominioId);

            //Condominio
            modelBuilder.Entity<Condominio>()
                .ToTable("Condominio");

            modelBuilder.Entity<Condominio>()
                    .HasKey(c => c.Id);

            modelBuilder.Entity<Condominio>()
                   .Property(c => c.GastoTotal)
                   .HasColumnType("float")
                   .IsRequired();

            modelBuilder.Entity<Condominio>().HasData(new[]
            {
                new Condominio(1, 1200, 700)
            }
                );

        }
    }
}

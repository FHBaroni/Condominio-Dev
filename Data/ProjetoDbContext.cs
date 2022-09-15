using CondominioDev.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioDev.Api.Data
{
    public class ProjetoDbContext : DbContext
    {
        private IConfiguration _configuration;
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
                .Property(h => h.DataNacimento)
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
               .HasOne<Condominio>(h => h.Condominio)
               .WithMany(c => c.Habitante)
               .HasForeignKey(h => h.CondominioId);

            //modelBuilder.Entity<Habitante>().HasData(new[]
            //{
            //    new Habitante(1, "Luis", "Melo", new DateTime(2000, 10, 22), 2500, 56998, 600)
            //}
            //    );


            //condominio
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
                 new Condominio(1)
            }
            );
        }
    }
}

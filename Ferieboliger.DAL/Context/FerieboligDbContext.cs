using Ferieboliger.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Context
{
    public class FerieboligDbContext : DbContext
    {
        private IConfiguration Configuration; 

       
        public FerieboligDbContext(DbContextOptions<FerieboligDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Ferieboliger;Trusted_Connection=True;");
            }
        }
        public virtual DbSet<Bruger> Brugere { get; set; }
        public virtual DbSet<Booking> Bookinger { get; set; }
        public virtual DbSet<Filoplysning> Filoplysninger { get; set; }
        public virtual DbSet<Feriebolig> Ferieboliger { get; set; }
        public virtual DbSet<Facilitet> Faciliteter { get; set; }
        public virtual DbSet<Adresse> Adresser { get; set; }
        public virtual DbSet<RedigerbarSide> RedigerbarSider { get; set; }
        public virtual DbSet<Leveringsadresse> Leveringsadresser { get; set; }
        public virtual DbSet<Spaerring> Spaerringer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Bruger
            modelBuilder.Entity<Bruger>(x =>
            {
                x.HasKey(c => c.Id);
                x.Property(x => x.Navn).HasMaxLength(255).IsRequired();
                x.HasMany(c => c.Bookinger);
            });

            // Spærring
            modelBuilder.Entity<Spaerring>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(c => c.Feriebolig).WithMany(c => c.Spaerringer).HasForeignKey(c => c.FerieboligId);
            });

            // Booking
            modelBuilder.Entity<Booking>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(c => c.Bruger).WithMany(c => c.Bookinger).HasForeignKey(c => c.BrugerId);

                x.HasOne(c => c.Feriebolig).WithMany(c => c.Bookinger).HasForeignKey(c => c.FerieboligId);
            });

            // Adresse
            modelBuilder.Entity<Adresse>(x =>
            {
                x.HasKey(c => c.Id);
                x.HasOne(c => c.Feriebolig).WithOne(c => c.Adresse);
            });

            // Facilitet
            modelBuilder.Entity<Facilitet>(x =>
            {
                x.HasKey(c => c.Id);
                x.HasMany(c => c.Ferieboliger).WithMany(x => x.Faciliteter);
            });

            // FileInformation


            // Feriebolig
            modelBuilder.Entity<Feriebolig>(x =>
            {
                x.HasKey(c => c.Id);
            });

            //Redigerbare undersider
            modelBuilder.Entity<RedigerbarSide>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Content);
                x.Property(x => x.Type).IsRequired();
            });

            // Leveringsadresse
            modelBuilder.Entity<Leveringsadresse>(x =>
            {
                x.HasKey(c => c.Id);
                x.HasOne(c => c.Booking).WithOne(c => c.Leveringsadresse);
            });
        }
    }
}

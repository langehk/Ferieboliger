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
        public FerieboligDbContext(DbContextOptions<FerieboligDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=Ferieboliger;Trusted_Connection=True;");
            }
        }
        public virtual DbSet<Bruger> Brugere { get; set; }
        public virtual DbSet<Booking> Bookings{ get; set; }
        public virtual DbSet<Filoplysning> FileInformations{ get; set; }
        public virtual DbSet<Feriebolig> VacationHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //// User
            //modelBuilder.Entity<Bruger>(x =>
            //{
            //    x.HasKey(c => c.Id);
            //    x.Property(x => x.Navn).HasMaxLength(255).IsRequired();

            //    x.HasOne(c => c.Booking).WithOne(c => c.Bruger);
            //});



            // Booking


            // FileInformation


            // VacationHouse


        }
    }
}

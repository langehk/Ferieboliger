using Ferieboliger.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Context
{
    public class FerieboligDbContext : IdentityDbContext
    {
        public FerieboligDbContext(DbContextOptions<FerieboligDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(c => c.Id);
                x.Property(x => x.Name).HasMaxLength(255).IsRequired();
            });
        }
    }
}

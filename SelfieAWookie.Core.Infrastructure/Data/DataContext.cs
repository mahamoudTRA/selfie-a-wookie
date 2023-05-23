using System;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Domain.Models;
using SelfieAWookie.core.Infrastructure.Data.EntityTypeConfiguration;
using SelfieAWookie.Core.Framework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SelfieAWookie.Core.Infrastructure.Data
{
    public class DataContext: /*DbContext*/ IdentityDbContext, IUnitOfWork
    {
        public DataContext(DbContextOptions options) : base(options) {}

        //public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DataContext() : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PictureEntityTypeConfiguration());

            //modelBuilder.Entity<Selfie>().ToTable("Selfie");
        }

        public DbSet<Selfie> Selfies { get; set; }

        public DbSet<Wookie> Wookies { get; set; }

        public DbSet<Picture> Pictures { get; set; }
    }
}


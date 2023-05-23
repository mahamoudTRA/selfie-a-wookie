using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Domain.Models;

namespace SelfieAWookie.core.Infrastructure.Data.EntityTypeConfiguration
{
    public class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
    {
        public SelfieEntityTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            builder.ToTable("Selfie");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Wookie)
                   .WithMany(x => x.Selfies)
                   .HasForeignKey(e => e.WookieId);
        }
    }
}


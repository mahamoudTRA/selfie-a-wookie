using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Domain.Models;

namespace SelfieAWookie.core.Infrastructure.Data.EntityTypeConfiguration
{
    public class WookieEntityTypeConfiguration : IEntityTypeConfiguration<Wookie>
    {
        public WookieEntityTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Wookie> builder)
        {
            builder.ToTable("Wookie");
            builder.HasKey(x => x.Id);
            
        }
    }
}


using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Domain.Models;

namespace SelfieAWookie.core.Infrastructure.Data.EntityTypeConfiguration
{
    public class PictureEntityTypeConfiguration : IEntityTypeConfiguration<Picture>
    {
        public PictureEntityTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture");
            builder.HasKey(x => x.Id);
        }
    }
}


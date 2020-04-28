using DomainLayer;
using DomainLayer.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceLayer.Configuration
{
    public class ApplicationArtistConfig
    {
        public ApplicationArtistConfig(EntityTypeBuilder<Artist> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            entityBuilder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            entityBuilder.Property(x => x.LogoUrl).HasMaxLength(100).IsRequired();
        }
    }
}

using DomainLayer;
using DomainLayer.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceLayer.Configuration
{
    public class ApplicationSongConfig
    {
        public ApplicationSongConfig(EntityTypeBuilder<Song> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            entityBuilder.Property(x => x.DurationTime).IsRequired();
        }
    }
}

using DomainLayer;
using DomainLayer.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceLayer.Configuration
{
    public class WarehouseMovementConfig
    {
        public WarehouseMovementConfig(EntityTypeBuilder<WarehouseMovement> entityBuilder)
        {

        }
    }
}

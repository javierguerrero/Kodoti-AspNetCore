using System;
using System.Collections.Generic;
using System.Text;

namespace DtoLayer
{
    public class WarehouseMovementDto
    {
        public int WarehouseMovementId { get; set; }
        public ProductDto Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}

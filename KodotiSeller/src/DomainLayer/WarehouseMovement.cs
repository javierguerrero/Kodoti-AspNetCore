using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class WarehouseMovement
    {
        public int WarehouseMovementId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}

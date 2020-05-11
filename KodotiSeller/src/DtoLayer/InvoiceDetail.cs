using System;
using System.Collections.Generic;
using System.Text;

namespace DtoLayer
{
    public class InvoiceDetailDto
    {
        public int InvoiceDetailId { get; set; }
        public InvoiceDto Invoice { get; set; }
        public int InvoiceId { get; set; }
        public ProductDto Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}

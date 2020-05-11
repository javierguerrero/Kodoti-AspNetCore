using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DomainLayer
{
    public class Invoice
    {
        public string InvoiceId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public List<InvoiceDetail> Details { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
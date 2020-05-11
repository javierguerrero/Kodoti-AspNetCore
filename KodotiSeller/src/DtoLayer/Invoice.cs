using System;
using System.Collections.Generic;

namespace DtoLayer
{
    public class InvoiceDto
    {
        public string InvoiceId { get; set; }
        public ClientDto Client { get; set; }
        public int ClientId { get; set; }
        public List<InvoiceDetailDto> Details { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
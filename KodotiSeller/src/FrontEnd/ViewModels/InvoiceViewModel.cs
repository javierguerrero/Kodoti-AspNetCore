using DomainLayer;
using DtoLayer;
using System.Collections.Generic;

namespace FrontEnd.ViewModels
{
    public class InvoiceViewModel
    {
        public IEnumerable<ClientDto> Clients { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public string NextNumber { get; set; }
    }
}
using CommonLayer;
using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceNumberService _invoiceNumberService;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public InvoiceController(
            IInvoiceNumberService invoiceNumberService,
            IClientService clientService,
            IProductService productService)
        {
            _invoiceNumberService = invoiceNumberService;
            _clientService = clientService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var invoiceNumber = await _invoiceNumberService.GetCurrent();

            return View(new InvoiceViewModel
            {
                Clients = await _clientService.GetAll(),
                Products = await _productService.GetAll(),
                NextNumber = InvoiceNumberHelper.GetNextNumber(invoiceNumber.Year, invoiceNumber.Current)
            });
        }
    }
}
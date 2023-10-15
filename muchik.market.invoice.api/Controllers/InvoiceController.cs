using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using muchik.market.invoice.application.dto;
using muchik.market.invoice.application.dto.Creates;
using muchik.market.invoice.application.interfaces;

namespace muchik.market.invoice.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("getAllInvoices")]
        public IActionResult GetAllInvoices()
        {
            return Ok(_invoiceService.GetAllInvoices());
        }

        [HttpGet("{id}")]
        public IActionResult FindInvoice(int id)
        {
            return Ok(_invoiceService.FindInvoice(id));
        }

        [HttpPost]
        public IActionResult CreateInvoice([FromBody] CreateInvoiceDto createInvoiceDto)
        {
            _invoiceService.CreateInvoice(createInvoiceDto);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateInvoice([FromBody] UpdateInvoiceDto updateInvoiceDto)
        {
            _invoiceService.UpdateInvoice(updateInvoiceDto);
            return Ok();
        }
    }
}

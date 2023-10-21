using muchik.market.invoice.application.dto;
using muchik.market.invoice.application.dto.Creates;
using muchik.market.invoice.domain.entities;

namespace muchik.market.invoice.application.interfaces
{
    public interface IInvoiceService
    {
        ICollection<InvoiceDto> GetAllInvoices();
        InvoiceDto FindInvoice(int Id);
        Task<bool> CreateInvoice(CreateInvoiceDto createPaymentDto);
        void UpdateInvoice(UpdateInvoiceDto updateInvoiceDto);

    }
}

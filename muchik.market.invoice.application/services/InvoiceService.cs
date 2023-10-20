using AutoMapper;
using muchik.market.invoice.application.dto;
using muchik.market.invoice.application.dto.Creates;
using muchik.market.invoice.application.interfaces;
using muchik.market.invoice.domain.entities;
using muchik.market.invoice.domain.interfaces;

namespace muchik.market.invoice.application.services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IMapper mapper, IInvoiceRepository invoiceRepository) 
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        public ICollection<InvoiceDto> GetAllInvoices()
        {
            var invoices = _invoiceRepository.List();
            var invoicesDto = _mapper.Map<ICollection<InvoiceDto>>(invoices);
            return invoicesDto;
        }

        public InvoiceDto FindInvoice(int Id)
        {
            var invoice = _invoiceRepository.GetById(Id);
            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);
            return invoiceDto;
        }

        public void CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(createInvoiceDto);
            _invoiceRepository.Add(invoice);
            //return _invoiceRepository.Save();
            _invoiceRepository.Save();
        }

        public void UpdateInvoice(UpdateInvoiceDto updateInvoiceDto)
        {
            var invoiceDto = _mapper.Map<Invoice>(updateInvoiceDto);
            _invoiceRepository.Update(invoiceDto);
            //return _invoiceRepository.Save();
            _invoiceRepository.Save();
        }

    }
}

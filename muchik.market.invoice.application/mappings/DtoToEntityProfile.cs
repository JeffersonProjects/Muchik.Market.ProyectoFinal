using AutoMapper;
using muchik.market.invoice.application.dto;
using muchik.market.invoice.application.dto.Creates;
using muchik.market.invoice.domain.entities;

namespace muchik.market.invoice.application.mappings
{
    public class DtoToEntityProfile : Profile
    {
       public DtoToEntityProfile() 
       {
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<UpdateInvoiceDto, Invoice>();

        }
    }
}

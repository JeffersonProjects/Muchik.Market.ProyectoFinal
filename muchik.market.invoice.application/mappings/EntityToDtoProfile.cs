using AutoMapper;
using muchik.market.invoice.application.dto;
using muchik.market.invoice.domain.entities;

namespace muchik.market.invoice.application.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<Invoice, InvoiceDto>();
        }
    }
}

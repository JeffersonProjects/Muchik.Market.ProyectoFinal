using AutoMapper;
using muchik.market.pay.application.dto;
using muchik.market.pay.domain.entities;

namespace muchik.market.pay.application.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<Payment, PaymentDto>();
        }
    }
}

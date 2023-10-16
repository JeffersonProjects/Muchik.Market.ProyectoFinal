using AutoMapper;
using muchik.market.transaction.application.dto;
using muchik.market.transaction.application.dto.Creates;
using muchik.market.transaction.domain.entities;

namespace muchik.market.transaction.application.mappings
{
    public class DtoToEntityProfile : Profile
    {
       public DtoToEntityProfile() 
       {
            CreateMap<TransactionsDto, Transactions>();
            CreateMap<CreateTransactionsDto, Transactions>();
        }
    }
}

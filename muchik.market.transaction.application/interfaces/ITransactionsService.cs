using muchik.market.transaction.application.dto;
using muchik.market.transaction.application.dto.Creates;
using muchik.market.transaction.domain.entities;

namespace muchik.market.transaction.application.interfaces
{
    public interface ITransactionsService
    {
        Task<ICollection<TransactionsDto>> GetAsync();
        Task<TransactionsDto?> GetAsync(string id);
        Task CreateAsync(TransactionsDto newTransactions);

    }
}

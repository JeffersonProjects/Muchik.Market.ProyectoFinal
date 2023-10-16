using muchik.market.transaction.domain.entities;
using muchik.market.transaction.domain.interfaces;
using muchik.market.transaction.infraestructure.context;

namespace muchik.market.transaction.infraestructure.repositories
{
    public class TransactionsRepository : GenericRepository<Transactions>, ITransactionsRepository
    {
        public TransactionsRepository(TransactionsContext context) : base(context) { }
    }
}

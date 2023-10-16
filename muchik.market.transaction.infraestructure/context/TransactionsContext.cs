using Microsoft.EntityFrameworkCore;
using muchik.market.transaction.domain.entities;

namespace muchik.market.transaction.infraestructure.context
{
    public class TransactionsContext : DbContext
    {
        public TransactionsContext(DbContextOptions<TransactionsContext> options) : base(options)
        {
        }

        public DbSet<Transactions> Transactions { get; set; } = null!;

    }
}

using Microsoft.EntityFrameworkCore;
using muchik.market.invoice.domain.entities;
using muchik.market.invoice.domain.interfaces;
using muchik.market.invoice.infraestructure.context;

namespace muchik.market.invoice.infraestructure.repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceContext context) : base(context) { }

    }
}

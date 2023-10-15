using muchik.market.pay.domain.entities;
using muchik.market.pay.domain.interfaces;
using muchik.market.pay.infraestructure.context;

namespace muchik.market.pay.infraestructure.repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentContext context) : base(context) { }
    }
}

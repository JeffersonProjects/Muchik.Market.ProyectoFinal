using muchik.market.pay.application.dto.Creates;

namespace muchik.market.pay.application.interfaces
{
    public interface IPaymentService
    {
        //bool CreatePayment(CreatePaymentDto createPaymentDto);
        void CreatePayment(CreatePaymentDto createPaymentDto);

    }
}

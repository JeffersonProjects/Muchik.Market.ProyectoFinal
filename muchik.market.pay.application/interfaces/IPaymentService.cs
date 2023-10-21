using muchik.market.pay.application.dto.Creates;

namespace muchik.market.pay.application.interfaces
{
    public interface IPaymentService
    {
        Task<bool> CreatePayment(CreatePaymentDto createPaymentDto);
        //void CreatePayment(CreatePaymentDto createPaymentDto);

    }
}

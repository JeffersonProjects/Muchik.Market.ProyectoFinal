using AutoMapper;
using muchik.market.pay.application.dto.Creates;
using muchik.market.pay.application.interfaces;
using muchik.market.pay.domain.entities;
using muchik.market.pay.domain.interfaces;

namespace muchik.market.pay.application.services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository) 
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        //public bool CreatePayment(CreatePaymentDto createPaymentDto)
        public void CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var payment = _mapper.Map<Payment>(createPaymentDto);
            _paymentRepository.Add(payment);
            //return _paymentRepository.Save();
            _paymentRepository.Save();
        }
    }
}

using AutoMapper;
using muchik.market.domain.bus;
using muchik.market.pay.application.commands;
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
        private readonly IEventBus _eventBus;

        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository, IEventBus eventBus) 
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _eventBus = eventBus;
        }

        public async Task<bool> CreatePayment(CreatePaymentDto createPaymentDto)
        //public void CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var payment = _mapper.Map<Payment>(createPaymentDto);
            _paymentRepository.Add(payment);

            var successRegister = _paymentRepository.Save();

            if (successRegister)
            {
                await _eventBus.SendCommand(new CreatePaymentCommand(payment.Id_Invoice, payment.Amount));
            }

            return successRegister;
        }
    }
}

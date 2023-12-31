﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using muchik.market.pay.application.dto.Creates;
using muchik.market.pay.application.interfaces;

namespace muchik.market.pay.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("CreatePayment")]
        public IActionResult CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        {
            _paymentService.CreatePayment(createPaymentDto);
            return Ok();
        }
    }
}

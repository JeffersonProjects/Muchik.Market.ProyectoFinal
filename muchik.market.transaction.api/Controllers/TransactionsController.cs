using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using muchik.market.transaction.application.dto;
using muchik.market.transaction.application.dto.Creates;
using muchik.market.transaction.application.interfaces;
using muchik.market.transaction.domain.entities;

namespace muchik.market.transaction.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet]
        public async Task<ICollection<TransactionsDto>> GetTransactions() =>
            await _transactionsService.GetTransactionsAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TransactionsDto>> GetTransactions(string id)
        {
            var transactions = await _transactionsService.GetTransactionsAsync(id);

            if (transactions is null)
            {
                return NotFound();
            }

            return transactions;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactions([FromBody] TransactionsDto TransactionsDto)
        {
            await _transactionsService.CreateTransactionsAsync(TransactionsDto);

            return CreatedAtAction(nameof(GetTransactions), new { id = TransactionsDto.Id_Transaction }, TransactionsDto);
        }

    }
}

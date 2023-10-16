using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using muchik.market.transaction.application.dto;
using muchik.market.transaction.application.dto.Creates;
using muchik.market.transaction.application.interfaces;
using muchik.market.transaction.domain.entities;
using muchik.market.transaction.domain.interfaces;
using System.Transactions;

namespace muchik.market.transaction.application.services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IMongoCollection<Transactions> _transactionsCollection;
        private readonly IMapper _mapper;

        public TransactionsService(IMapper mapper,
            IOptions<TransactionsStoreDatabaseSettings> transactionsStoreDatabaseSettings)
        {
            _mapper = mapper;

            var mongoClient = new MongoClient(
                transactionsStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                transactionsStoreDatabaseSettings.Value.DatabaseName);

            _transactionsCollection = mongoDatabase.GetCollection<Transactions>(
                transactionsStoreDatabaseSettings.Value.TransactionCollectionName);
        }

        public async Task<ICollection<TransactionsDto>> GetAsync()
        {         
            var transactions = await _transactionsCollection.Find(_ => true).ToListAsync();
            var transactionsDto = _mapper.Map<ICollection<TransactionsDto>>(transactions);
            return transactionsDto;
        }

        public async Task<TransactionsDto?> GetAsync(string id)
        {
            var transaction = await _transactionsCollection.Find(x => x.Id_Transaction == id).FirstOrDefaultAsync();
            var transactionDto = _mapper.Map<TransactionsDto>(transaction);
            return transactionDto;
        }          

        public async Task CreateAsync(TransactionsDto transactionsDto)
        {
            var transactions = _mapper.Map<Transactions>(transactionsDto);
            await _transactionsCollection.InsertOneAsync(transactions);
        }            

    }
}

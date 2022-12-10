using CarePatreonTest.Core.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Builders;
using Microsoft.Azure.CosmosRepository.Paging;
using System.Linq.Expressions;
using System.Transactions;

namespace CarePatreonTest.Application.Tests.TestInfra
{
    public class InMemoryClientDomainEventRepository : IRepository<ClientDomainEvent>
    {
        private readonly IList<ClientDomainEvent> clientDomainEvents;
        public InMemoryClientDomainEventRepository()
        {
            this.clientDomainEvents = new List<ClientDomainEvent>();
        }

        public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<int> CountAsync(Expression<Func<ClientDomainEvent, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask CreateAsBatchAsync(IEnumerable<ClientDomainEvent> items, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ClientDomainEvent> CreateAsync(ClientDomainEvent value, CancellationToken cancellationToken = default)
        {
            this.clientDomainEvents.Add(value);

            return ValueTask.FromResult(value);
        }

        public ValueTask<IEnumerable<ClientDomainEvent>> CreateAsync(IEnumerable<ClientDomainEvent> values, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask DeleteAsBatchAsync(IEnumerable<ClientDomainEvent> items, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask DeleteAsync(ClientDomainEvent value, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask DeleteAsync(string id, string? partitionKeyValue = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask DeleteAsync(string id, PartitionKey partitionKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> ExistsAsync(string id, string? partitionKeyValue = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> ExistsAsync(string id, PartitionKey partitionKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> ExistsAsync(Expression<Func<ClientDomainEvent, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ClientDomainEvent> GetAsync(string id, string? partitionKeyValue = null, CancellationToken cancellationToken = default)
        {
            return ValueTask.FromResult(this.clientDomainEvents.FirstOrDefault(x => x.Id == id));
        }

        public ValueTask<ClientDomainEvent> GetAsync(string id, PartitionKey partitionKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<ClientDomainEvent>> GetAsync(Expression<Func<ClientDomainEvent, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var result = this.clientDomainEvents.AsQueryable().Where(predicate);

            return ValueTask.FromResult(result.AsEnumerable());
        }

        public ValueTask<IEnumerable<ClientDomainEvent>> GetByQueryAsync(string query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<ClientDomainEvent>> GetByQueryAsync(QueryDefinition queryDefinition, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IPage<ClientDomainEvent>> PageAsync(Expression<Func<ClientDomainEvent, bool>>? predicate = null, int pageSize = 25, string? continuationToken = null, bool returnTotal = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IPageQueryResult<ClientDomainEvent>> PageAsync(Expression<Func<ClientDomainEvent, bool>>? predicate = null, int pageNumber = 1, int pageSize = 25, bool returnTotal = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TResult> QueryAsync<TResult>(Microsoft.Azure.CosmosRepository.Specification.ISpecification<ClientDomainEvent, TResult> specification, CancellationToken cancellationToken = default) where TResult : IQueryResult<ClientDomainEvent>
        {
            throw new NotImplementedException();
        }

        public ValueTask<ClientDomainEvent?> TryGetAsync(string id, string? partitionKeyValue = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask UpdateAsBatchAsync(IEnumerable<ClientDomainEvent> items, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ClientDomainEvent> UpdateAsync(ClientDomainEvent value, CancellationToken cancellationToken = default, bool ignoreEtag = false)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<ClientDomainEvent>> UpdateAsync(IEnumerable<ClientDomainEvent> values, CancellationToken cancellationToken = default, bool ignoreEtag = false)
        {
            throw new NotImplementedException();
        }

        public ValueTask UpdateAsync(string id, Action<IPatchOperationBuilder<ClientDomainEvent>> builder, string? partitionKeyValue = null, CancellationToken cancellationToken = default, string? etag = null)
        {
            throw new NotImplementedException();
        }
    }
}

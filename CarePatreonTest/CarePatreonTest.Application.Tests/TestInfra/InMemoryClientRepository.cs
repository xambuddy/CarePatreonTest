using Bogus;
using CarePatreonTest.Core.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Builders;
using Microsoft.Azure.CosmosRepository.Paging;
using System.Linq.Expressions;

namespace CarePatreonTest.Application.Tests.TestInfra
{
    public class InMemoryClientRepository : IRepository<Client>
    {
        private readonly IList<Client> clients;

        public InMemoryClientRepository()
        {
            this.clients = new Faker<Client>()
                .RuleFor(x => x.Id, f => f.Random.Guid().ToString())
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.PhoneNumber, f => f.Person.Phone)
                .Generate(5);
        }

        public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<int> CountAsync(Expression<Func<Client, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask CreateAsBatchAsync(IEnumerable<Client> items, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Client> CreateAsync(Client value, CancellationToken cancellationToken = default)
        {
            value.Id = Guid.NewGuid().ToString();

            this.clients.Add(value);

            return ValueTask.FromResult(value);
        }

        public ValueTask<IEnumerable<Client>> CreateAsync(IEnumerable<Client> values, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask DeleteAsBatchAsync(IEnumerable<Client> items, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask DeleteAsync(Client value, CancellationToken cancellationToken = default)
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

        public ValueTask<bool> ExistsAsync(Expression<Func<Client, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Client> GetAsync(string id, string? partitionKeyValue = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Client> GetAsync(string id, PartitionKey partitionKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<Client>> GetAsync(Expression<Func<Client, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<Client>> GetByQueryAsync(string query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<Client>> GetByQueryAsync(QueryDefinition queryDefinition, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IPage<Client>> PageAsync(Expression<Func<Client, bool>>? predicate = null, int pageSize = 25, string? continuationToken = null, bool returnTotal = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IPageQueryResult<Client>> PageAsync(Expression<Func<Client, bool>>? predicate = null, int pageNumber = 1, int pageSize = 25, bool returnTotal = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TResult> QueryAsync<TResult>(Microsoft.Azure.CosmosRepository.Specification.ISpecification<Client, TResult> specification, CancellationToken cancellationToken = default) where TResult : IQueryResult<Client>
        {
            throw new NotImplementedException();
        }

        public ValueTask<Client?> TryGetAsync(string id, string? partitionKeyValue = null, CancellationToken cancellationToken = default)
        {
            var existing = this.clients.FirstOrDefault(x => x.Id == id);

            return ValueTask.FromResult(existing);
        }

        public ValueTask UpdateAsBatchAsync(IEnumerable<Client> items, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Client> UpdateAsync(Client value, CancellationToken cancellationToken = default, bool ignoreEtag = false)
        {
            var client = this.clients.Where(t => t.Id == value.Id)?.FirstOrDefault();

            if (client != null)
            {
                client.FirstName = value.FirstName;
                client.LastName = value.LastName;
                client.Email = value.Email;
                client.PhoneNumber = value.PhoneNumber;
            }

            return ValueTask.FromResult(client);
        }

        public ValueTask<IEnumerable<Client>> UpdateAsync(IEnumerable<Client> values, CancellationToken cancellationToken = default, bool ignoreEtag = false)
        {
            throw new NotImplementedException();
        }

        public ValueTask UpdateAsync(string id, Action<IPatchOperationBuilder<Client>> builder, string? partitionKeyValue = null, CancellationToken cancellationToken = default, string? etag = null)
        {
            throw new NotImplementedException();
        }
    }
}

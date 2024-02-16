using Cosmos.Diagnoses.Api.CrossCutting.Settings;
using Cosmos.Diagnoses.Api.Domain.Models;
using Cosmos.Diagnoses.Api.Domain.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Infrastructure.Repositories
{
    public class CIE10CodeRepository(CosmosClient cosmosClient, IConfiguration configuration) : ICIE10CodeRepository
    {
        private readonly Container? _container = cosmosClient.GetContainer(configuration["Data:DatabaseName"], configuration["Data:CIE10CodeContainerName"]);

        public async Task<IEnumerable<CIE10Code>> GetAllAsync()
        {
            var query = _container!.GetItemQueryIterator<CIE10Code>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<CIE10Code>();
            while (query!.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<CIE10Code> GetByIdAsync(string id)
        {
            var query = await _container!.ReadItemAsync<CIE10Code>(id, PartitionKey.None);
            return query.Resource;
        }
    }
}

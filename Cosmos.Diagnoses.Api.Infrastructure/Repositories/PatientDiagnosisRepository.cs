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
    public class PatientDiagnosisRepository(CosmosClient cosmosClient, IConfiguration configuration) : IPatientDiagnosisRepository
    {
        private readonly Container? _container = cosmosClient.GetContainer(configuration["Data:DatabaseName"], configuration["Data:PatientDiagnosisContainerName"]);

        public async Task<PatientDiagnosis> CreateAsync(PatientDiagnosis patientDiagnosis)
        {
            var response = await _container!.CreateItemAsync(patientDiagnosis, PartitionKey.None);
            return response.Resource;
        }

        public async Task<IEnumerable<PatientDiagnosis>> GetAllAsync()
        {
            var query = _container!.GetItemQueryIterator<PatientDiagnosis>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<PatientDiagnosis>();
            while (query!.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<PatientDiagnosis> GetByIdAsync(string id)
        {
            var query = await _container!.ReadItemAsync<PatientDiagnosis>(id, PartitionKey.None);
            return query.Resource;
        }
    }
}

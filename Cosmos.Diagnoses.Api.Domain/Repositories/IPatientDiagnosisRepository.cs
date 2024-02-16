using Cosmos.Diagnoses.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Repositories
{
    public interface IPatientDiagnosisRepository
    {
        Task<IEnumerable<PatientDiagnosis>> GetAllAsync();

        Task<PatientDiagnosis> GetByIdAsync(string id);

        Task<PatientDiagnosis> CreateAsync(PatientDiagnosis patientDiagnosis);
    }
}

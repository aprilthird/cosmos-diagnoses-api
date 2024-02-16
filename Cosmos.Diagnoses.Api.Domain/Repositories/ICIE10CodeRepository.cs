using Cosmos.Diagnoses.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Repositories
{
    public interface ICIE10CodeRepository
    {
        Task<IEnumerable<CIE10Code>> GetAllAsync();

        Task<CIE10Code> GetByIdAsync(string id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Base.Interfaces
{
    public interface IBaseEntity
    {
        DateTime? DeletedAt { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        string DeletedBy { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}

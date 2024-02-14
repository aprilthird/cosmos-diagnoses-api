using Cosmos.Diagnoses.Api.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Base.Implementations
{
    public class IdentityUserEntity : IdentityUser, IBaseEntity
    {

        [NotMapped]
        public DateTime? DeletedAt { get; set; }

        [NotMapped]
        public string DeletedBy { get; set; }

        [NotMapped]
        public DateTime? CreatedAt { get; set; }

        [NotMapped]
        public string CreatedBy { get; set; }

        [NotMapped]
        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        public string UpdatedBy { get; set; }

    }
}

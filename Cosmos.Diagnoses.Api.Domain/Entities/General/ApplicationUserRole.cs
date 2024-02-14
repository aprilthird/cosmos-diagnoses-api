using Cosmos.Diagnoses.Api.Domain.Base.Implementations;
using Cosmos.Diagnoses.Api.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Entities.General
{
    public class ApplicationUserRole : IdentityUserRole<string>, IAggregateRoot
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}

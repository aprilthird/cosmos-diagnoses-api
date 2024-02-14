using Cosmos.Diagnoses.Api.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Entities.General
{
    public class ApplicationRole : IdentityRole, IAggregateRoot
    {
        public int Priority { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}

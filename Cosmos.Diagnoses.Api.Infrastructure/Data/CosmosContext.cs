using Cosmos.Diagnoses.Api.Domain.Entities.General;
using Cosmos.Diagnoses.Api.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Infrastructure.Data
{
    public class CosmosContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly List<AuditEntry> _temporaryPropertyAuditEntries;

        public CosmosContext(DbContextOptions<CosmosContext> options) : base(options)
        {
            _httpContextAccessor = new HttpContextAccessor();
            _temporaryPropertyAuditEntries = new List<AuditEntry>();

            Database.SetCommandTimeout(Int32.MaxValue);
        }

        public CosmosContext(DbContextOptions<CosmosContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _temporaryPropertyAuditEntries = new List<AuditEntry>();

            Database.SetCommandTimeout(Int32.MaxValue);
        }
    }
}

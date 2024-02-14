using Cosmos.Diagnoses.Api.Domain.Base.Implementations;
using Cosmos.Diagnoses.Api.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Entities.General
{
    public class ApplicationUser : IdentityUserEntity, IKeyNumber, ISoftDelete, ITimestamp, IAggregateRoot
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string MaternalSurname { get; set; }

        [Required]
        [MaxLength(250)]
        public string PaternalSurname { get; set; }

        [MaxLength(750)]
        public string FullName { get; set; }

        public string Picture { get; set; }

        public DateTime? BirthDate { get; set; }

        public int Sex { get; set; } /*AKDEMIC.CORE.Constants.GeneralConstants.SEX*/

        [MaxLength(8)]
        public string Dni { get; set; }

        public string Address { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}

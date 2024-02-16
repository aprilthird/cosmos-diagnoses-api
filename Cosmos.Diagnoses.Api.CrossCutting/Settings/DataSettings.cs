using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.CrossCutting.Settings
{
    public class DataSettings
    {
        public string? DatabaseName { get; set; }

        public string? PatientDiagnosisContainerName { get; set; }

        public string? CIE10CodeContainerName { get; set; }
    }
}

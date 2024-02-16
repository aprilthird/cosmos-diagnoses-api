using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Models
{
    public class CIE10Code
    {
        //[JsonPropertyName("id_CIE")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("CodigoDiagnostico")]
        public string? DiagnosisCode { get; set; }

        [JsonPropertyName("Descripcion")]
        public string? Description { get; set; }
    }
}

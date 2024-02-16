using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Models
{
    public class PatientDiagnosis
    {
        //[JsonPropertyName("id_diagnostico")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("id_paciente")]
        public string? PatientId { get; set; }

        [JsonPropertyName("id_CIE")]
        public string? CIE10CodeId { get; set; }

        [JsonPropertyName("FechaRegistro")]
        public DateTime RegisterDate { get; set; }
    }
}

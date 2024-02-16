using Cosmos.Diagnoses.Api.Domain.Models;
using Cosmos.Diagnoses.Api.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Cosmos.Diagnoses.Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientDiagnosisController(IPatientDiagnosisRepository patientDiagnosisRepository, ICIE10CodeRepository codeRepository) : ControllerBase
    {
        private readonly IPatientDiagnosisRepository _patientDiagnosisRepository = patientDiagnosisRepository;
        private readonly ICIE10CodeRepository _codeRepository = codeRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _patientDiagnosisRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            try
            {
                var result = await _patientDiagnosisRepository.GetByIdAsync(id);
                return Ok(result);
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound($"No encontrado un diagnóstico de paciente con ID '{id}'.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientDiagnosis model)
        {
            if (string.IsNullOrEmpty(model.CIE10CodeId))
                return BadRequest();

            try
            {
                var code = await _codeRepository.GetByIdAsync(model.CIE10CodeId);
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound) 
            { 
                return NotFound($"No encontrado un CIE 10 con ID '{model.CIE10CodeId}'.");
            }

            model.Id = Guid.NewGuid().ToString();
            var createdRecord = await _patientDiagnosisRepository.CreateAsync(model);
            return CreatedAtAction(nameof(Get), new { id = createdRecord.Id }, createdRecord);
        }
    }
}

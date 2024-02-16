﻿using Cosmos.Diagnoses.Api.Domain.Models;
using Cosmos.Diagnoses.Api.Domain.Repositories;
using Cosmos.Diagnoses.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.Diagnoses.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CIE10CodeController(ICIE10CodeRepository codeRepository) : ControllerBase
    {
        private readonly ICIE10CodeRepository _codeRepository = codeRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _codeRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _codeRepository.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}

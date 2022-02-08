using AutoMapper;
using System.Threading.Tasks;
using Pasticceria.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Pasticceria.Api.Resources;
using Pasticceria.Core.Services;
using System.Collections.Generic;
using Pasticceria.Api.Validators;

namespace Pasticceria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolciController : ControllerBase
    {
        private readonly IDolceService _dolceService;
        private readonly IMapper _mapper;

        public DolciController(IDolceService dolceService, IMapper mapper)
        {
            this._mapper = mapper;
            this._dolceService = dolceService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DolceResource>>> GetAllDolci()
        {
            try
            {
                var dolci = await _dolceService.GetAllDolci();
                if (dolci is null)
                    return NoContent();

                var dolceResource = _mapper.Map<IEnumerable<Dolce>, IEnumerable<DolceResource>>(dolci);

                return Ok(dolceResource);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DolceResource>> GetDolceById(int id)
        {
            try
            {
                var dolci = await _dolceService.GetDolceById(id);
                if (dolci is null)
                    return NoContent();

                var dolceResource = _mapper.Map<Dolce, DolceResource>(dolci);

                return Ok(dolceResource);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<DolceResource>> CreateDolce([FromBody] SaveDolceResource saveDolceResource)
        {
            try
            {
                var validator = new SaveDolceResourceValidator();
                var validationResult = await validator.ValidateAsync(saveDolceResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var dolceToCreate = _mapper.Map<SaveDolceResource, Dolce>(saveDolceResource);

                var newDolce = await _dolceService.CreateDolce(dolceToCreate);

                var dolce = await _dolceService.GetDolceById(newDolce.Id);

                var dolceResource = _mapper.Map<Dolce, DolceResource>(dolce);

                return Ok(dolceResource);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DolceResource>> UpdateDolce(int id, [FromBody] SaveDolceResource saveDolceResource)
        {
            try
            {
                var validator = new SaveDolceResourceValidator();
                var validationResult = await validator.ValidateAsync(saveDolceResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var dolceToUpdated = await _dolceService.GetDolceById(id);

                if (dolceToUpdated is null)
                    return NotFound();

                var dolce = _mapper.Map<SaveDolceResource, Dolce>(saveDolceResource);

                await _dolceService.UpdateDolce(dolceToUpdated, dolce);

                var updatedDolce = await _dolceService.GetDolceById(id);

                var updatedDolceResource = _mapper.Map<Dolce, DolceResource>(updatedDolce);

                return Ok(updatedDolceResource);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDolce(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                var dolce = await _dolceService.GetDolceById(id);

                if (dolce is null)
                    return NotFound();

                await _dolceService.DeleteDolce(dolce);

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

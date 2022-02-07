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

        /// <summary>
        /// Dolci controller
        /// </summary>
        /// <param name="dolceService"></param>
        /// <param name="mapper"></param>
        public DolciController(IDolceService dolceService, IMapper mapper)
        {
            this._mapper = mapper;
            this._dolceService = dolceService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DolceResource>>> GetAllDolci()
        {
            var dolci = await _dolceService.GetAllDolci();
            var dolceResource = _mapper.Map<IEnumerable<Dolce>, IEnumerable<DolceResource>>(dolci);

            return Ok(dolceResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DolceResource>> GetDolceById(int id)
        {
            var dolci = await _dolceService.GetDolceById(id);
            var dolceResource = _mapper.Map<Dolce, DolceResource>(dolci);

            return Ok(dolceResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<DolceResource>> CreateDolce([FromBody] SaveDolceResource saveDolceResource)
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

        [HttpPut("{id}")]
        public async Task<ActionResult<DolceResource>> UpdateDolce(int id, [FromBody] SaveDolceResource saveDolceResource)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDolce(int id)
        {
            var dolce = await _dolceService.GetDolceById(id);

            await _dolceService.DeleteDolce(dolce);

            return NoContent();
        }
    }
}

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
    public class IngredientiOfDolceController : ControllerBase
    {
        private readonly IIngredientiOfDolceService _ingredientiOfDolceService;
        private readonly IMapper _mapper;

        public IngredientiOfDolceController(IIngredientiOfDolceService ingredientiOfDolceService, IMapper mapper)
        {
            this._mapper = mapper;
            this._ingredientiOfDolceService = ingredientiOfDolceService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<IngredientiOfDolceResource>>> GetAllIngredientiOfDolci()
        {
            var ingredientiOfDolci = await _ingredientiOfDolceService.GetAllIngredientiOfDolci();
            var ingredientiOfDolciResource = _mapper.Map<IEnumerable<IngredientiOfDolce>, IEnumerable<IngredientiOfDolceResource>>(ingredientiOfDolci);

            return Ok(ingredientiOfDolciResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientiOfDolceResource>> GetIngredienteOfDolceById(int id)
        {
            var ingredienteOfDolci = await _ingredientiOfDolceService.GetIngredienteOfDolceById(id);
            var ingredienteOfDolceResource = _mapper.Map<IngredientiOfDolce, IngredientiOfDolceResource>(ingredienteOfDolci);

            return Ok(ingredienteOfDolceResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<IngredientiOfDolceResource>> CreateIngredienteOfDolce([FromBody] SaveIngredientiOfDolciResource saveIngredienteOfDolceResource)
        {
            var validator = new SaveIngredientiOfDolceResourceValidator();
            var validationResult = await validator.ValidateAsync(saveIngredienteOfDolceResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var ingredienteOfDolceToCreate = _mapper.Map<SaveIngredientiOfDolciResource, IngredientiOfDolce>(saveIngredienteOfDolceResource);

            var newIngredienteOfDolce = await _ingredientiOfDolceService.CreateIngredienteOfDolce(ingredienteOfDolceToCreate);

            var ingredienteOfDolce = await _ingredientiOfDolceService.GetIngredienteOfDolceById(newIngredienteOfDolce.Id);

            var ingredienteOfDolceResource = _mapper.Map<IngredientiOfDolce, IngredientiOfDolceResource>(ingredienteOfDolce);

            return Ok(ingredienteOfDolceResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IngredientiOfDolceResource>> UpdateIngredienteOfDolce(int id, [FromBody] SaveIngredientiOfDolciResource saveIngredienteOfDolceResource)
        {
            var validator = new SaveIngredientiOfDolceResourceValidator();
            var validationResult = await validator.ValidateAsync(saveIngredienteOfDolceResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var ingredienteOfDolceToUpdate = await _ingredientiOfDolceService.GetIngredienteOfDolceById(id);

            if (ingredienteOfDolceToUpdate is null)
                return NotFound();

            var ingredienteOfDolce = _mapper.Map<SaveIngredientiOfDolciResource, IngredientiOfDolce>(saveIngredienteOfDolceResource);

            await _ingredientiOfDolceService.UpdateIngredienteOfDolce(ingredienteOfDolceToUpdate, ingredienteOfDolce);

            var updatedIngredienteOfDolce = await _ingredientiOfDolceService.GetIngredienteOfDolceById(id);
            var updatedIngredienteOfDolceResource = _mapper.Map<IngredientiOfDolce, IngredientiOfDolceResource>(updatedIngredienteOfDolce);

            return Ok(updatedIngredienteOfDolceResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredienteOfDolce(int id)
        {
            if (id == 0)
                return BadRequest();

            var ingredienteOfDolce = await _ingredientiOfDolceService.GetIngredienteOfDolceById(id);

            if (ingredienteOfDolce is null)
                return NotFound();

            await _ingredientiOfDolceService.DeleteIngredienteOfDolce(ingredienteOfDolce);

            return NoContent();
        }
    }
}

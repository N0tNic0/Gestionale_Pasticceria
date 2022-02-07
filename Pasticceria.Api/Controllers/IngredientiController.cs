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
    public class IngredientiController : ControllerBase
    {
        private readonly IIngredienteService _ingredienteService;
        private readonly IMapper _mapper;

        public IngredientiController(IIngredienteService ingredienteService, IMapper mapper)
        {
            this._mapper = mapper;
            this._ingredienteService = ingredienteService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<IngredienteResource>>> GetAllIngredienti()
        {
            var ingredienti = await _ingredienteService.GetAll();
            var ingredienteResource = _mapper.Map<IEnumerable<Ingrediente>, IEnumerable<IngredienteResource>>(ingredienti);

            return Ok(ingredienteResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredienteResource>> GetIngredienteById(int id)
        {
            var ingrediente = await _ingredienteService.GetIngredienteById(id);
            var ingredienteResource = _mapper.Map<Ingrediente, IngredienteResource>(ingrediente);

            return Ok(ingredienteResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<IngredienteResource>> CreateIngrediente([FromBody] SaveIngredienteResource saveIngredienteResource)
        {
            var validator = new SaveIngredienteResourceValidator();
            var validationResult = await validator.ValidateAsync(saveIngredienteResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var ingredienteToCreate = _mapper.Map<SaveIngredienteResource, Ingrediente>(saveIngredienteResource);

            var newIngrediente = await _ingredienteService.CreateIngrediente(ingredienteToCreate);

            var ingrediente = await _ingredienteService.GetIngredienteById(newIngrediente.Id);

            var ingredienteResource = _mapper.Map<Ingrediente, IngredienteResource>(ingrediente);

            return Ok(ingredienteResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IngredienteResource>> UpdateIngrediente(int id, [FromBody] SaveIngredienteResource saveIngredienteResource)
        {
            var validator = new SaveIngredienteResourceValidator();
            var validationResult = await validator.ValidateAsync(saveIngredienteResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var ingredienteToUpdate = await _ingredienteService.GetIngredienteById(id);

            if (ingredienteToUpdate is null)
                return NotFound();

            var ingrediente = _mapper.Map<SaveIngredienteResource, Ingrediente>(saveIngredienteResource);

            await _ingredienteService.UpdateIngrediente(ingredienteToUpdate, ingrediente);

            var updatedIngrediente = await _ingredienteService.GetIngredienteById(id);
            var updatedIngredienteResource = _mapper.Map<Ingrediente, IngredienteResource>(updatedIngrediente);

            return Ok(updatedIngredienteResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngrediente(int id)
        {
            if (id == 0)
                return BadRequest();

            var ingrediente = await _ingredienteService.GetIngredienteById(id);

            if (ingrediente is null)
                return NotFound();

            await _ingredienteService.DeleteIngrediente(ingrediente);

            return NoContent();
        }
    }
}

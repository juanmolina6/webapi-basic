using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergyService _allergyService;
        private readonly IValidator<AllergyRequestDto> _validator;

        public AllergiesController(
            IAllergyService allergyService,
            IValidator<AllergyRequestDto> validator)
        {
            _allergyService = allergyService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allergies = await _allergyService.GetAll();
            return Ok(allergies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var allergy = await _allergyService.GetById(id);
            return Ok(allergy);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AllergyRequestDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var allergy = await _allergyService.Add(dto);

            return Ok(allergy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AllergyRequestDto dto)
        {
            var allergy = await _allergyService.Update(dto, id);

            if (allergy == null)
            {
                return NotFound();
            }

            return Ok(allergy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var allergy = await _allergyService.Delete(id);

            if (allergy == null)
            {
                return NotFound();
            }

            return Ok(allergy);
        }
    }
}
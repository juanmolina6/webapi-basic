using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineCategoriesController : ControllerBase
    {
        private readonly IVaccineCategoryService _vaccineCategoryService;
        private readonly IValidator<VaccineCategoryRequestDto> _validator;

        public VaccineCategoriesController(
            IVaccineCategoryService vaccineCategoryService,
            IValidator<VaccineCategoryRequestDto> validator)
        {
            _vaccineCategoryService = vaccineCategoryService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccineCategories = await _vaccineCategoryService.GetAll();

            return Ok(vaccineCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccineCategory = await _vaccineCategoryService.GetById(id);

            return Ok(vaccineCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VaccineCategoryRequestDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var vaccineCategory = await _vaccineCategoryService.Add(dto);

            return Ok(vaccineCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VaccineCategoryRequestDto dto)
        {
            var vaccineCategory = await _vaccineCategoryService.Update(dto, id);

            if (vaccineCategory == null)
            {
                return NotFound();
            }

            return Ok(vaccineCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaccineCategory = await _vaccineCategoryService.Delete(id);

            if (vaccineCategory == null)
            {
                return NotFound();
            }

            return Ok(vaccineCategory);
        }
    }
}

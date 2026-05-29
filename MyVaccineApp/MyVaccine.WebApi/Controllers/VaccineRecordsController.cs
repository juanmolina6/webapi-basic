using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineRecordsController : ControllerBase
    {
        private readonly IVaccineRecordService _service;
        private readonly IValidator<VaccineRecordRequestDto> _validator;

        public VaccineRecordsController(
            IVaccineRecordService service,
            IValidator<VaccineRecordRequestDto> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(VaccineRecordRequestDto dto)
        {
            var validation = await _validator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            return Ok(await _service.Add(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VaccineRecordRequestDto dto)
        {
            var result = await _service.Update(dto, id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
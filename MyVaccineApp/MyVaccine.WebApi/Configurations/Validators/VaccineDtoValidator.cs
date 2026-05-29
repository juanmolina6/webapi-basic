using FluentValidation;
using MyVaccine.WebApi.Dtos.Vaccine;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class VaccineDtoValidator : AbstractValidator<VaccineRequestDto>
    {
        public VaccineDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
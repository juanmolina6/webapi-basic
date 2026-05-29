using FluentValidation;
using MyVaccine.WebApi.Dtos.VaccineCategory;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class VaccineCategoryDtoValidator : AbstractValidator<VaccineCategoryRequestDto>
    {
        public VaccineCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
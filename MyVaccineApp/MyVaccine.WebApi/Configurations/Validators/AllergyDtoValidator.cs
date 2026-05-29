using FluentValidation;
using MyVaccine.WebApi.Dtos.Allergy;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class AllergyDtoValidator : AbstractValidator<AllergyRequestDto>
    {
        public AllergyDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.UserId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
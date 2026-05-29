using FluentValidation;
using MyVaccine.WebApi.Dtos.VaccineRecord;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class VaccineRecordDtoValidator : AbstractValidator<VaccineRecordRequestDto>
    {
        public VaccineRecordDtoValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.DependentId).GreaterThan(0);
            RuleFor(x => x.VaccineId).GreaterThan(0);

            RuleFor(x => x.DateAdministered)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.AdministeredLocation)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.AdministeredBy)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
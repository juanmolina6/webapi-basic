using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class AllergyRepository : BaseRepository<Allergy>, IAllergyRepository
    {
        public AllergyRepository(MyVaccineAppDbContext context) : base(context)
        {
        }
    }
}

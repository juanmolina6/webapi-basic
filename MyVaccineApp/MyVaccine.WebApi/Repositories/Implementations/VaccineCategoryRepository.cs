using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineCategoryRepository : BaseRepository<VaccineCategory>, IVaccineCategoryRepository
    {
        public VaccineCategoryRepository(MyVaccineAppDbContext context) : base(context)
        {
        }
    }
}
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineRepository : BaseRepository<Vaccine>, IVaccineRepository
    {
        public VaccineRepository(MyVaccineAppDbContext context) : base(context)
        {
        }
    }
}
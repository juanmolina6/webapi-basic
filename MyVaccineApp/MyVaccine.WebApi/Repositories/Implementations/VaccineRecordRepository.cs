using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineRecordRepository : BaseRepository<VaccineRecord>, IVaccineRecordRepository
    {
        public VaccineRecordRepository(MyVaccineAppDbContext context) : base(context)
        {
        }
    }
}
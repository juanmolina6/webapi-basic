using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class FamilyGroupRepository : BaseRepository<FamilyGroup>, IFamilyGroupRepository
    {
        public FamilyGroupRepository(MyVaccineAppDbContext context) : base(context)
        {
        }
    }
}
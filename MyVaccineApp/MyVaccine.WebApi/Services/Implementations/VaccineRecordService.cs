using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class VaccineRecordService : IVaccineRecordService
    {
        private readonly IVaccineRecordRepository _repository;
        private readonly IMapper _mapper;

        public VaccineRecordService(
            IVaccineRecordRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VaccineRecordResponseDto> Add(VaccineRecordRequestDto request)
        {
            var entity = new VaccineRecord
            {
                UserId = request.UserId,
                DependentId = request.DependentId,
                VaccineId = request.VaccineId,
                DateAdministered = request.DateAdministered,
                AdministeredLocation = request.AdministeredLocation,
                AdministeredBy = request.AdministeredBy
            };

            await _repository.Add(entity);

            return _mapper.Map<VaccineRecordResponseDto>(entity);
        }

        public async Task<VaccineRecordResponseDto> Delete(int id)
        {
            var entity = await _repository
                .FindBy(x => x.VaccineRecordId == id)
                .FirstOrDefaultAsync();

            await _repository.Delete(entity);

            return _mapper.Map<VaccineRecordResponseDto>(entity);
        }

        public async Task<IEnumerable<VaccineRecordResponseDto>> GetAll()
        {
            var list = await _repository.GetAll()
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<VaccineRecordResponseDto>>(list);
        }

        public async Task<VaccineRecordResponseDto> GetById(int id)
        {
            var entity = await _repository
                .FindByAsNoTracking(x => x.VaccineRecordId == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<VaccineRecordResponseDto>(entity);
        }

        public async Task<VaccineRecordResponseDto> Update(VaccineRecordRequestDto request, int id)
        {
            var entity = await _repository
                .FindBy(x => x.VaccineRecordId == id)
                .FirstOrDefaultAsync();

            entity.UserId = request.UserId;
            entity.DependentId = request.DependentId;
            entity.VaccineId = request.VaccineId;
            entity.DateAdministered = request.DateAdministered;
            entity.AdministeredLocation = request.AdministeredLocation;
            entity.AdministeredBy = request.AdministeredBy;

            await _repository.Update(entity);

            return _mapper.Map<VaccineRecordResponseDto>(entity);
        }
    }
}

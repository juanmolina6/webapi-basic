using AutoMapper;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DEPENDENT
            CreateMap<Dependent, DependentRequestDto>().ReverseMap();
            CreateMap<Dependent, DependentResponseDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.DependentId))
                .ReverseMap();

            // ALLERGY
            CreateMap<Allergy, AllergyRequestDto>().ReverseMap();
            CreateMap<Allergy, AllergyResponseDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.AllergyId))
                .ReverseMap();

            // FAMILY GROUP
            CreateMap<FamilyGroup, FamilyGroupRequestDto>().ReverseMap();
            CreateMap<FamilyGroup, FamilyGroupResponseDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.FamilyGroupId))
                .ReverseMap();

            // VACCINE
            CreateMap<Vaccine, VaccineRequestDto>().ReverseMap();
            CreateMap<Vaccine, VaccineResponseDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.VaccineId))
                .ReverseMap();

            // VACCINE CATEGORY
            CreateMap<VaccineCategory, VaccineCategoryRequestDto>().ReverseMap();
            CreateMap<VaccineCategory, VaccineCategoryResponseDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.VaccineCategoryId))
                .ReverseMap();

            // VACCINE RECORD
            CreateMap<VaccineRecord, VaccineRecordRequestDto>().ReverseMap();
            CreateMap<VaccineRecord, VaccineRecordResponseDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.VaccineRecordId))
                .ReverseMap();
        }
    }
}
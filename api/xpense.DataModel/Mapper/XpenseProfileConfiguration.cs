using AutoMapper;

namespace xpense.DataModel.Mapper
{
    public class XpenseProfileConfiguration : Profile
    {
        public XpenseProfileConfiguration():base("XpenseProfileConfiguration")
        {
            CreateMap<Organisation, Dto.OrganisationDto>();
            CreateMap<Dto.OrganisationDto, Organisation>();
            CreateMap<Employee, Dto.EmployeeDto>()
                .ForMember(o => o.OrganisationKey, t => t.MapFrom(x => x.Organisation.Key));
            CreateMap<Dto.EmployeeDto, Employee>();
        }
    }
}

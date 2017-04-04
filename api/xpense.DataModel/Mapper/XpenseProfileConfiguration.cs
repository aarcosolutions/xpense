using AutoMapper;

namespace xpense.DataModel.Mapper
{
    public class XpenseProfileConfiguration : Profile
    {
        public XpenseProfileConfiguration():base("XpenseProfileConfiguration")
        {
            CreateMap<Organisation, Dto.OrganisationDto>();
        }
    }
}

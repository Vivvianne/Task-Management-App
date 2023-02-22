using AutoMapper;
using TaskManagement.Domain.Models.Options;
using TaskManagement.Domain.ViewModels.Options;

namespace TaskManagement.Domain
{
    /// <summary>
    /// Represents mapping profile
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<OptionEntityViewModel, Option>()
                .ReverseMap();
        }
    }
}

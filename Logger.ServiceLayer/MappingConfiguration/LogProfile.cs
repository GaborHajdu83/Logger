using AutoMapper;
using Logger.Dtos;
using Logger.Entities.Log;

namespace Logger.ServiceLayer.MappingConfiguration
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogDto, LogEntity>()
                .ForMember(d => d.Message, s => s.MapFrom(s => s.Message))
                .ForMember(d => d.LogLevel, s => s.MapFrom(s => s.LogLevel));
        }
    }
}

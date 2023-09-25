using AutoMapper;
using LogolendarzAPI.Models;
using LogolendarzAPI.Models.Dto;

namespace LogolendarzAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VisitDto, Visit>();
                config.CreateMap<Visit, VisitDto>();
            });
            return mappingConfig;
        }
    }
}

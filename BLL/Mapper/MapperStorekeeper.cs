using AutoMapper;
using BLL.ModelDto;
using DAL.Entities;

namespace BLL.Mapper
{
    public class MapperStorekeeper : Profile
    {
        public MapperStorekeeper()
        {
            CreateMap<Storekeeper, StorekeeperDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.SumKolDetail, opt => opt.MapFrom(src => src.SumKolDetail));

            CreateMap<StorekeeperDto, Storekeeper>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.SumKolDetail, opt => opt.MapFrom(src => src.SumKolDetail));
        }
    }
}

using AutoMapper;
using BLL.ModelDto;
using DAL.Entities;
using System;

namespace BLL.Mapper
{
    public class MapperDetail : Profile
    {
        public MapperDetail()
        {
            CreateMap<Detail, DetailDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.NomenclatureCode, opt => opt.MapFrom(src => src.NomenclatureCode))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(d => d.SpecAccount, opt => opt.MapFrom(src => src.SpecAccount))
                .ForMember(d => d.NameStorekeeper, opt => opt.MapFrom(src => src.Storekeeper.Name))
                .ForMember(d => d.Created, opt => opt.MapFrom(src => src.Created.ToString("dd/MM/yyyy")))
                .ForMember(d => d.DeleteDate, opt => opt.MapFrom(src => src.DeleteDate.ToString()));

            CreateMap<DetailDto, Detail>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.NomenclatureCode, opt => opt.MapFrom(src => src.NomenclatureCode))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(d => d.SpecAccount, opt => opt.MapFrom(src => src.SpecAccount))
             //   .ForMember(d => d.Storekeeper.Name, opt => opt.MapFrom(src => src.NameStorekeeper))
                .ForMember(d => d.Created, opt => opt.MapFrom(src => Convert.ToDateTime(src.Created)))
                .ForMember(d => d.DeleteDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.DeleteDate)));
        }
    }
}

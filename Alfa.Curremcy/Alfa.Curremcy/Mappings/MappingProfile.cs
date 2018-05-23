using Alfa.Curremcy.Models;
using Alfa.Curremcy.Models.BusinessModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alfa.Curremcy.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Currency, CurrencyViewModel>();

            CreateMap<Currency, SelectListItem>()
                .ForMember(up => up.Value, opt => opt.MapFrom(p => p.Id))
                .ForMember(up => up.Text, opt => opt.MapFrom(p => p.CharCode));

            CreateMap<CurrenciesList, CurrencyListViewModel>()
                .ForMember(up => up.SelectedCurrencyId, opt => opt.UseValue(""))
                .ForMember(up => up.SelectedCurrencyItems, opt => opt.MapFrom(p => p.Valute.Values))
                .ForMember(up => up.Currencies, opt => opt.MapFrom(p => p.Valute.Values));
        }
    }
}

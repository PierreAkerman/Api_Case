using AutoMapper;
using Case_Api.Data;
using Case_Api.DTO;

namespace Case_Api.Infrastructure.Profiles
{
    public class AdvertizerProfile : Profile
    {
        public AdvertizerProfile()
        {
            CreateMap<Advertizer, AdvertizerDto>().ReverseMap();
            CreateMap<Advertizer, CreateAdvertizerDto>().ReverseMap();
            CreateMap<Advertizer, UpdateAdvertizerDto>().ReverseMap();
        }
    }
}

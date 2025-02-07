using Ass1.DTOs;
using Ass1.Models;
using AutoMapper;

namespace Ass1.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Good, GoodDTO>().ReverseMap();
        }
    }
}

using AutoMapper;
using Domain.Dto;
using Domain.Models;

namespace Abschlussprojekt2021.Helpers
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<JobAd, JobAdDto>().ReverseMap();
        }
    }
}

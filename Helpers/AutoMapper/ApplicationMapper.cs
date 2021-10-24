using AutoMapper;
using Domain.Models;

namespace Helpers.AutoMapper
{
    class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<JobAd>
        }
    }
}

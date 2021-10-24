using AutoMapper;
using Domain.Dto;
using Domain.Models;

namespace Abschlussprojekt2021.Helpers
{
    /// <summary>
    /// This method contains the mapping configurations for the AutoMapper.
    /// 
    /// @warning This method must be in the web application, otherwise the dependency injection will not work.
    /// </summary>
    public class ModelMapper : Profile
    {
        /// <summary>
        ///  Mapping configurations for the JobAd class.
        /// </summary>
        public ModelMapper()
        {
            /// <value>Mapping configuration</value>
            CreateMap<JobAd, JobAdDto>().ReverseMap();
        }
    }
}

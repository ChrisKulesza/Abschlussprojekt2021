using AutoMapper;
using Domain.Dto;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class CreateJobAdModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateJobAdModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public JobAd JobAd { get; set; }
        public JobAdDto JobAdDto { get; set; }

        public RedirectResult OnPost()
        {
            // 
            JobAd newJobAd = new();

            // Check whether the transferred DTO object is valid. Negation of the result.
            if (!ModelState.IsValid)
            {
                // 
                return Redirect("Index");
            } else
            {
                // Mapping DTO to the JobAd class.
                newJobAd = _mapper.Map<JobAd>(JobAdDto);
            }


            _unitOfWork.JobAd.Insert(newJobAd);
            _unitOfWork.Complete();

            return Redirect("index");
        }

        public RedirectResult OnPostCancelButton()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Index");
            }
            
            return Redirect("Index");
        }
    }
}

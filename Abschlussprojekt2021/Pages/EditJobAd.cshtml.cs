using AutoMapper;
using Domain.Dto;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class EditJobAdModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobAd JobAd { get; set; }
        public JobAdDto Dto { get; set; }

        public EditJobAdModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            JobAd = _unitOfWork.JobAd.GetById(id);
            Dto = _mapper.Map<JobAdDto>(JobAd);
        }

        public RedirectResult OnPost(int id)
        {
            Dto.Id = id;
            JobAd jobAd = new();

            if (ModelState.IsValid)
            {
                jobAd = _mapper.Map<JobAd>(Dto);
            
                _unitOfWork.JobAd.Update(jobAd);
                _unitOfWork.Complete();
            }

            return Redirect("/Index");
        }

        public RedirectResult OnPostCancelButton()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Index");
            }

            return Redirect("/Index");
        }
    }
}

using AutoMapper;
using Domain.Dto;
using Domain.Interfaces;
using Domain.Models;
using Domain.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class JobDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobAd JobAd { get; set; }
        public InputModel Input { get; set; }
        public JobAdDto Dto { get; set; }

        public JobDetailsModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            JobAd = _unitOfWork.JobAd.GetById(id);
            Dto = _mapper.Map<JobAdDto>(JobAd);
        }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [StringLength(100, ErrorMessage = Constants.errorMessageStringLength, MinimumLength = 2)]
            [Display(Name = "Nachname, Vorname")]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = Constants.formEmail)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = Constants.formMessage)]
            public string Message { get; set; }

            public bool DSGVO { get; set; }
        }
    }
}

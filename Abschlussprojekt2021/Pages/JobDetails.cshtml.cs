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
        /// <value>Private field of the IUnitOfWork interface.</value>
        private readonly IUnitOfWork _unitOfWork;
        /// <value>Private field of the IMapper interface.</value>
        private readonly IMapper _mapper;

        /// <value>Property to prepopulate the input fields of the form.</value>
        public JobAd JobAd { get; set; }
        /// <value></value>
        public InputModel Input { get; set; }
        /// <value>DTO Property to capture the input of the user.</value>
        public JobAdDto Dto { get; set; }

        /// <summary>
        /// Dependency of the IUnitOfWork interface made available via constructor injection.
        /// </summary>
        /// <param name="unitOfWork">Initialization parameters IUnitOfWork.</param>
        /// <param name="mapper">Initialization parameters IMapper.</param>
        public JobDetailsModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// When the method is called, the data record with the matching ID is fetched.
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(int id)
        {
            // Retrieves the data record from the JobAd table from the database with the passed ID.
            JobAd = _unitOfWork.JobAd.GetById(id);
            // Mapping JobAd to the JobAdDto class.
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

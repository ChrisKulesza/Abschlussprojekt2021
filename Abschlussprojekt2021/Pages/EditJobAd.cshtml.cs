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
        /// <value>Private field of the IUnitOfWork interface.</value>
        private readonly IUnitOfWork _unitOfWork;
        /// <value>Private field of the IMapper interface.</value>
        private readonly IMapper _mapper;

        /// <value>Property to prepopulate the input fields of the form.</value>
        public JobAd JobAd { get; set; }
        /// <value>DTO Property to capture the input of the user.</value>
        public JobAdDto Dto { get; set; }

        /// <summary>
        /// Initializes a new instance. Dependency of the IUnitOfWork interface made 
        /// available via constructor injection.
        /// </summary>
        /// <param name="unitOfWork">Initialization parameters IUnitOfWork.</param>
        /// <param name="mapper">Initialization parameters IMapper.</param>
        public EditJobAdModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// When the method is called, the data record with the matching ID is fetched.
        /// </summary>
        /// <param name="id">The Id passed from the view.</param>
        public void OnGet(int id)
        {
            // Retrieves the data record from the JobAd table from the database with the passed ID.
            JobAd = _unitOfWork.JobAd.GetById(id);
            // Mapping JobAd to the JobAdDto class.
            Dto = _mapper.Map<JobAdDto>(JobAd);
        }

        /// <summary>
        /// When the method is called, the data record is updated with the matching ID.
        /// </summary>
        /// <param name="id">The Id passed from the view.</param>
        /// <returns>Forwarding to the index page.</returns>
        public RedirectResult OnPost(int id)
        {
            // Saving the passed id to the DTO instance.
            Dto.Id = id;

            // Check whether the transferred DTO object is valid. Negation of the result.
            if (ModelState.IsValid)
            {
                // Mapping DTO to the JobAd class.
                var jobAd = _mapper.Map<JobAd>(Dto);

                // Create a new record of the JobAd table in memory.
                _unitOfWork.JobAd.Update(jobAd);
                // Write the record in memory to the JobAd table in the database.
                _unitOfWork.CompleteAsync();
            }

            // Redirecting to the index page.
            return Redirect("/Index");
        }

        /// <summary>
        /// If the user presses the cancel button in the view, he will be redirected to the index page.
        /// </summary>
        /// <returns>Forwarding to the index page.</returns>
        public RedirectResult OnPostCancelButton()
        {
            // Check whether the transferred DTO object is valid. Negation of the result.
            if (!ModelState.IsValid)
            {
                // Redirecting to the index page.
                return Redirect("/Index");
            }

            // Redirecting to the index page.
            return Redirect("/Index");
        }
    }
}

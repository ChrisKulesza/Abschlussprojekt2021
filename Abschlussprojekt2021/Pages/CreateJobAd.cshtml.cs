using AutoMapper;
using Domain.Dto;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class CreateJobAdModel : PageModel
    {
        /// <value>Private field of the IUnitOfWork interface.</value>
        private readonly IUnitOfWork _unitOfWork;
        /// <value>Private field of the IMapper interface.</value>
        private readonly IMapper _mapper;
        /// <value>Private field for ILogger.</value>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance. Dependency of the IUnitOfWork interface made available via constructor injection.
        /// </summary>
        /// <param name="unitOfWork">Initialization parameters IUnitOfWork.</param>
        /// <param name="mapper">Initialization parameters IMapper.</param>
        public CreateJobAdModel(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateJobAdModel> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <value>Property to prepopulate the input fields of the form.</value>
        public JobAd JobAd { get; set; }
        /// <value>DTO Property to capture the input of the user.</value>
        public JobAdDto Dto { get; set; }

        /// <summary>
        /// Creates a new record in the database.
        /// </summary>
        /// <returns>Forwarding to the index page.</returns>
        public RedirectResult OnPost()
        {
            // Check whether the transferred DTO object is valid. Negation of the result.
            if (!ModelState.IsValid)
            {
                // Output error message on the console
                _logger.LogError("Invalid JobAd object sent from client.");
                // If the model is not valid then redirect the user to the index page.
                return Redirect("Index");
            } else
            {
                // Mapping DTO to the JobAd class.
                JobAd newJobAd = _mapper.Map<JobAd>(Dto);

                // Create a new record of the JobAd table in memory.
                _unitOfWork.JobAd.Insert(newJobAd);
                // Write the record in memory to the JobAd table in the database.
                _unitOfWork.CompleteAsync();
                // Log that a new data record with the name has been persisted.
                _logger.LogInformation($"New record with the Name: {newJobAd.Name} was persisted in the database.");
            }

            // Redirecting to the index page.
            return Redirect("Index");
        }

        /// <summary>
        /// If the user presses the cancel button in the view, he will be redirected to the index page.
        /// </summary>
        /// <returns>Forwarding to the index page.</returns>
        public RedirectResult OnPostCancelButton()
        {
            // Check whether the transferred data record is valid. (negated)
            if (!ModelState.IsValid)
            {
                // Output error message on the console
                _logger.LogError("Invalid JobAd object sent from client.");
                // Redirecting to the index page.
                return Redirect("Index");
            }

            // Redirecting to the index page.
            return Redirect("Index");
        }
    }
}

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
        // Review: Die Kommentare bringen keinen Mehrwert und machen den Code schwerer lesbar.
        // Nur sinnvoll, wenn irgendwo ein Automatismus eine Dokumentation über deinen Code erstellt.
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
                // Review: Normalerweise sollte ein Error nur geloggt werden,
                // wenn das Operation-Team daraufhin aktiv werden soll und zB einen Bug für die Entwickler anlegen muss.
                // In diesem Fall ist es aber eine Benutzereingabe, die falsch eingegeben wurde. Demnach nicht das Problem des Webseiten-Betreibers.
                // Wenn man die Info trotzdem haben möchte, dann sollte die Severity "Information" sein.

                // Output error message on the console
                _logger.LogError("Invalid JobAd object sent from client.");

                // Review: Aufgrund von UX würde ich hier kein Redirect machen, da dann zB bereits getätigte Eingaben erneut eingegeben werden müssen.

                // If the model is not valid then redirect the user to the index page.
                return Redirect("Index");

                // Review: Der Benutzer bekommt keinerlei Info warum etwas schiefgelaufen ist.
                // Eine einfache Möglichkeit dies zu erreichen wäre
                // cshtml
                // @if(!string.IsNullOrEmpty(Model.Message)) {
                //    < div class="alert alert-info">@Model.Message</div>
                // }
                // cs
                // public string Message { get; set; }
                // ...
                // if (!ModelState.IsValid) Message = "Ungültiger Input";
            }
            else
            {
                // Review: Warum wir ein JobAd und ein JobAdDto verwendet? Am Ende ist es die gleiche Datenstruktur. 
                // Ist es damit DB und UI entkoppelt sind?

                // Mapping DTO to the JobAd class.
                JobAd newJobAd = _mapper.Map<JobAd>(Dto);

                // Create a new record of the JobAd table in memory.
                _unitOfWork.JobAd.Insert(newJobAd);
                // Write the record in memory to the JobAd table in the database.
                _unitOfWork.CompleteAsync();
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

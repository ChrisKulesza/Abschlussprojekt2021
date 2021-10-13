using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Abschlussprojekt2021.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class JobDetailsModel : PageModel
    {
        private readonly IRepository<JobAd> _repository;
        private readonly ILogger<JobDetailsModel> _logger;

        public JobAd JobAd { get; set; }
        public InputModel Input { get; set; }

        public JobDetailsModel(IRepository<JobAd> repository, ILogger<JobDetailsModel> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task OnGet(int id)
        {
            JobAd = await _repository.GetByIdAsync(id);
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
            [Display(Name = "Email Adresse")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Nachricht")]
            public string Message { get; set; }

            public bool DSGVO { get; set; }
        }
    }
}

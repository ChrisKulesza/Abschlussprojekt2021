using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Abschlussprojekt2021.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class JobDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public JobAd JobAd { get; set; }
        public InputModel Input { get; set; }

        public JobDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            JobAd = _context.JobAds.Where(j => j.Id == id).FirstOrDefault();
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

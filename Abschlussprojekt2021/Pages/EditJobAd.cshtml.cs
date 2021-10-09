using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class EditJobAdModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public JobAd JobAd { get; set; }
        public InputModel Input { get; set; }

        public EditJobAdModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            JobAd = _context.JobAds.Where(j => j.Id == id).FirstOrDefault();
        }

        public async Task<RedirectResult> OnPostAsync(int id)
        {
            JobAd = _context.JobAds.Where(j => j.Id == id).FirstOrDefault();

            if (ModelState.IsValid)
            {
                JobAd.Name = Input.Name;
                JobAd.Position = Input.Position;
                JobAd.Description = Input.Description;
                JobAd.MainSkills = Input.MainSkills;
                JobAd.Region = Input.Region;
                JobAd.StartDate = Input.StartDate;
            
                _context.JobAds.Update(JobAd);
                await _context.SaveChangesAsync();
            }

            return Redirect("/Index");
        }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Position { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Description { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Main Skills")]
            public string MainSkills { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Region { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd.MMM.yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Start date")]
            public DateTime StartDate { get; set; }
        }
    }
}

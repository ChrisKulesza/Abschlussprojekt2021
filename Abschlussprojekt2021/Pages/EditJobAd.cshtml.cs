using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class EditJobAdModel : PageModel
    {
        private readonly IRepository<JobAd> _repository;
        public JobAd JobAd { get; set; }
        public InputModel Input { get; set; }

        public EditJobAdModel(IRepository<JobAd> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync(int id)
        {
            JobAd = await _repository.GetByIdAsync(id);
        }

        public async Task<RedirectResult> OnPostAsync(int id)
        {
            JobAd = await _repository.GetByIdAsync(id);

            if (ModelState.IsValid)
            {
                JobAd.Name = Input.Name;
                JobAd.Position = Input.Position;
                JobAd.Description = Input.Description;
                JobAd.MainSkills = Input.MainSkills;
                JobAd.Region = Input.Region;
                JobAd.StartDate = Input.StartDate;

                await _repository.UpdateAsync(JobAd);
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

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
    public class CreateJobAdModel : PageModel
    {
        private readonly IRepository<JobAd> _repository;

        public CreateJobAdModel(IRepository<JobAd> repository)
        {
            _repository = repository;
        }

        public InputModel Input { get; set; }


        public async Task<RedirectResult> OnPostInsertAsync()
        {
            JobAd jobAd = new()
            {
                Name = Input.Name,
                Position = Input.Position,
                Description = Input.Description,
                MainSkills = Input.MainSkills,
                Region = Input.Region,
                StartDate = Input.StartDate,
                Timeframe = Input.Timeframe
            };

            await _repository.InsertAsync(jobAd);

            return Redirect("index");
        }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            //[StringLength(30, ErrorMessage = "Test", MinimumLength = 5)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Position { get; set; }

            public string Description { get; set; }

            [Display(Name = "Main Skills")]
            public string MainSkills { get; set; }
            
            public string Region { get; set; }

            [DataType(DataType.Date)]
            public DateTime StartDate { get; set; }

            [DataType(DataType.Date)]
            public DateTime Timeframe { get; set; }
        }
    }
}

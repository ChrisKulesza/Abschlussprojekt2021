using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Abschlussprojekt2021.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

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


        public RedirectResult OnPostInsert()
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

            _repository.Insert(jobAd);

            return Redirect("index");
        }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = Constants.formJobAdName)]
            //[StringLength(30, ErrorMessage = "Test", MinimumLength = 5)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Position { get; set; }

            [Display(Name = Constants.formDescription)]
            public string Description { get; set; }

            [Display(Name = Constants.formMainSkills)]
            public string MainSkills { get; set; }
            
            public string Region { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = Constants.formStartDate)]
            public DateTime StartDate { get; set; }

            [DataType(DataType.Date)]
            public DateTime Timeframe { get; set; }
        }
    }
}

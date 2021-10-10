using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Abschlussprojekt2021.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class CreateJobAdModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateJobAdModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public InputModel Input { get; set; }
        public List<string> toolsList { get; set; }

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

        public void OnGet()
        {
            // Get RTE Options | Syncfusion
            RichTextOptions rteOptions = new RichTextOptions();
            rteOptions.GetRTEOptionsMinimumScope();
        }

        public async Task<RedirectResult> OnPostAsync()
        {
            JobAd jobAd = new JobAd()
            {
                Name = Input.Name,
                Position = Input.Position,
                Description = Input.Description,
                MainSkills = Input.MainSkills,
                Region = Input.Region,
                StartDate = Input.StartDate,
                Timeframe = Input.Timeframe
            };

            await _context.AddAsync(jobAd);
            await _context.SaveChangesAsync();

            return Redirect("index");
        }
    }
}

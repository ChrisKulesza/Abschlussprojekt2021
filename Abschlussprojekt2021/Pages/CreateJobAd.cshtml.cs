using Abschlussprojekt2021.Resources;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class CreateJobAdModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateJobAdModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public InputModel Input { get; set; }

        public RedirectResult OnPost()
        {
            JobAd jobAd = new();

            if (!ModelState.IsValid)
            {
                return Redirect("Index");
            } else
            {
                jobAd.Name = Input.Name;
                jobAd.Position = Input.Position;
                jobAd.Description = Input.Description;
                jobAd.MainSkills = Input.MainSkills;
                jobAd.Region = Input.Region;
                jobAd.StartDate = Input.StartDate;
            }

            _unitOfWork.JobAd.Insert(jobAd);
            _unitOfWork.SaveChanges();

            return Redirect("index");
        }

        public RedirectResult OnPostCancelButton()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Index");
            }
            
            return Redirect("Index");
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
        }
    }
}

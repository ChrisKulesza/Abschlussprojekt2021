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
    public class EditJobAdModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobAd JobAd { get; set; }
        public InputModel Input { get; set; }

        public EditJobAdModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            JobAd = _unitOfWork.JobAd.GetById(id);
        }

        public RedirectResult OnPost(int id)
        {
            JobAd = _unitOfWork.JobAd.GetById(id);

            if (ModelState.IsValid)
            {
                JobAd.Name = Input.Name;
                JobAd.Position = Input.Position;
                JobAd.Description = Input.Description;
                JobAd.MainSkills = Input.MainSkills;
                JobAd.Region = Input.Region;
                JobAd.StartDate = Input.StartDate;
            }

            _unitOfWork.JobAd.Update(JobAd);
            _unitOfWork.SaveChanges();

            return Redirect("/Index");
        }

        public RedirectResult OnPostCancelButton()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Index");
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
            [Display(Name = Constants.formMainSkills)]
            public string MainSkills { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Region { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd.MMM.yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = Constants.formStartDate)]
            public DateTime StartDate { get; set; }
        }
    }
}

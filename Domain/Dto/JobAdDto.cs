using Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dto
{
    /// <summary>
    /// Provides the transfer object of the JobAd class and its properties.
    /// </summary>
    public class JobAdDto
    {
        [Key]
        public int Id { get; set; }

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

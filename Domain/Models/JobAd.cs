using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// This class provides the model of the job posting. Via which the data is accessed.
    /// </summary>
    public class JobAd
    {
        /// <value>Id of the job posting.</value>
        [Key]
        public int Id { get; set; }

        /// <value>Name of the job posting.</value>
        public string Name { get; set; }

        /// <value>Position to be filled by the job posting.</value>
        public string Position { get; set; }

        /// <value>Description of the job posting.</value>
        public string Description { get; set; }

        /// <value>Defines the region in which the job posting is valid.</value>
        public string MainSkills { get; set; }

        /// <value></value>
        public string Region { get; set; }

        /// <value>Defines the start date of the job posting.</value>
        public DateTime StartDate { get; set; }
    }
}

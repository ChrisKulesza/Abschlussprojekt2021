using System;
using System.ComponentModel.DataAnnotations;

namespace Abschlussprojekt2021.Models
{
    public class JobAd
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string MainSkills { get; set; }
        public string Region { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Timeframe { get; set; }
    }
}

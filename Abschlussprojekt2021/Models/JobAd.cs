using System;
using System.Collections.Generic;

#nullable disable

namespace Abschlussprojekt2021.Models
{
    public partial class JobAd
    {
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

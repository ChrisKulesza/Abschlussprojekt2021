using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public List<JobAd> JobAds { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            JobAds = _context.JobAds.ToList();
        }

        [HttpPost]
        public RedirectResult OnPostRemove(int id)
        {
            var jobAd = _context.JobAds.Where(j => j.Id == id).FirstOrDefault();

            _context.Remove(jobAd);
            _context.SaveChanges();

            return Redirect("Index");
        }
    }
}

//public async Task<RedirectResult> OnPostAsync()
//{
//    int jobAdId = JobAdId;
//    var jobAd = _context.JobAds.Where(j => j.Id == jobAdId).FirstOrDefault();

//    return Redirect("/index");
//}
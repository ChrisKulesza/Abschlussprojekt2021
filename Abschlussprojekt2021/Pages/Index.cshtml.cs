using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IRepository<JobAd> _repository;
        public List<JobAd> JobAds { get; set; }

        public IndexModel(IRepository<JobAd> repository)
        {
            _repository = repository;
        }

        // OnPost handler - Syncfusion UrlAdaptor | GetDbData
        public JsonResult OnPostDataSource([FromBody] DataManagerRequest dm)
        {
            var data = _repository.GetAllSynfusion();

            int count = data.Cast<JobAd>().Count();
            return dm.RequiresCounts ? new JsonResult(new { result = data.Skip(dm.Skip).Take(dm.Take), count = count }) : new JsonResult(data);
        }

        // OnPost handler - Syncfusion UrlAdaptor | Delete
        public void OnPostDelete([FromBody]CRUDModel<JobAd> value)
        {
            int id = Convert.ToInt32(value.Value.Id);
            _repository.Delete(id);

            //return RedirectToPage("Index");
        }

        // OnPost handler - Syncfusion UrlAdaptor | Duplicate
        public void OnPostDuplicate([FromBody]CRUDModel<JobAd> value)
        {
            int id = Convert.ToInt32(value.Value.Id);
            JobAd job = new()
            {
                Name = value.Value.Name,
                Position = value.Value.Position,
                Description = value.Value.Description,
                MainSkills = value.Value.MainSkills,
                Region = value.Value.Region,
                StartDate = value.Value.StartDate
            };

            _repository.Insert(job);
            //return RedirectToPage("Index");
        }
    }
}
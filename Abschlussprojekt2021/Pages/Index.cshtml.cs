using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        //public List<JobAd> JobAds { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // OnPost handler - Syncfusion UrlAdaptor | GetDbData
        public JsonResult OnPostDataSource([FromBody] DataManagerRequest dm)
        {
            var data = _unitOfWork.JobAd.GetAll();

            int count = data.Cast<JobAd>().Count();
            return dm.RequiresCounts ? new JsonResult(new { result = data.Skip(dm.Skip).Take(dm.Take), count = count }) : new JsonResult(data);
        }

        // OnPost handler - Syncfusion UrlAdaptor | Delete
        public void OnPostDelete([FromBody]CRUDModel<JobAd> value)
        {
            int id = Convert.ToInt32(value.Value.Id);
            var entity = _unitOfWork.JobAd.GetById(id);

            _unitOfWork.JobAd.Remove(entity);
            _unitOfWork.SaveChanges();
            //return RedirectToPage("Index");
        }

        // OnPost handler - Syncfusion UrlAdaptor | Duplicate
        public void OnPostDuplicate([FromBody]CRUDModel<JobAd> entity)
        {
            //int id = Convert.ToInt32(value.Value.Id);
            JobAd job = new()
            {
                Name = entity.Value.Name,
                Position = entity.Value.Position,
                Description = entity.Value.Description,
                MainSkills = entity.Value.MainSkills,
                Region = entity.Value.Region,
                StartDate = entity.Value.StartDate
            };

            _unitOfWork.JobAd.Insert(job);
            _unitOfWork.SaveChanges();
            //return RedirectToPage("Index");
        }
    }
}
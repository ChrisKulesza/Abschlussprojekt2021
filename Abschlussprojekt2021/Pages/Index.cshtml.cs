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
        /// <value>Private field of the Unit of work.</value>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Creates an instance of the class unit of work. This interface provides the DbContext.
        /// </summary>
        /// <param name="unitOfWork">The entity needed for referencing.</param>
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // OnPost handler - Syncfusion UrlAdaptor | GetDbData
        public JsonResult OnPostDataSource([FromBody] DataManagerRequest dm)
        {
            // Fetches all records of the JobAd table from the database using Unit of work
            var data = _unitOfWork.JobAd.GetAll();

            // Counts the number of data records in the transferred IEnumerable and casts this explicitly beforehand.
            int count = data.Cast<JobAd>().Count();
            // Returns the data records received from the database in the form of a JsonResult.
            return dm.RequiresCounts ? new JsonResult(new { result = data.Skip(dm.Skip).Take(dm.Take), count = count }) : new JsonResult(data);
        }

        // OnPost handler - Syncfusion UrlAdaptor | Delete
        public void OnPostDelete([FromBody]CRUDModel<JobAd> value)
        {
            // Gets the ID of the transferred data record and performs an explicit type conversion to integer.
            int id = Convert.ToInt32(value.Value.Id);
            // Looks for the appropriate data record based on the passed ID.
            var entity = _unitOfWork.JobAd.GetById(id);

            _unitOfWork.JobAd.Remove(entity);
            _unitOfWork.Complete();
            //return RedirectToPage("Index");
        }

        // OnPost handler - Syncfusion UrlAdaptor | Duplicate
        public void OnPostDuplicate([FromBody]CRUDModel<JobAd> entity)
        {
            // Creates an instance of the JoBAd class to save the user input.
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
            _unitOfWork.Complete();
            //return RedirectToPage("Index");
        }
    }
}
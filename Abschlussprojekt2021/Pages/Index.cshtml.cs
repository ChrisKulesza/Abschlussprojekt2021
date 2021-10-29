using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;

namespace Abschlussprojekt2021.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        /// <value>Private field of the IUnitOfWork interface.</value>
        private readonly IUnitOfWork _unitOfWork;
        /// <value>Private field for ILogger.</value>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance. Dependency of the IUnitOfWork interface made 
        /// available via constructor injection.
        /// </summary>
        /// <param name="unitOfWork">Initialization parameters IUnitOfWork.</param>
        public IndexModel(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Reads all data records in the JobAds table from the database. 
        /// These are then transferred to the Syncfusion UI component DataGrid.
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        public JsonResult OnPostDataSource([FromBody] DataManagerRequest dm)
        {
            // Fetches all records of the JobAd table from the database using Unit of work
            var data = _unitOfWork.JobAd.GetAll();
            _logger.LogInformation("Returned all JobAds from database.");

            // Counts the number of data records in the transferred IEnumerable and casts this explicitly beforehand.
            int count = data.Cast<JobAd>().Count();
            // Returns the data records received from the database in form of a JsonResult.
            return dm.RequiresCounts ? new JsonResult(new { result = data.Skip(dm.Skip).Take(dm.Take), count = count }) : new JsonResult(data);
        }

        // OnPost handler - Syncfusion UrlAdaptor | Delete
        public void OnPostDelete([FromBody]CRUDModel<JobAd> value)
        {
            // Gets the ID of the transferred data record and performs an explicit type conversion to integer.
            int id = Convert.ToInt32(value.Value.Id);
            // Looks for the appropriate data record based on the passed ID.
            var entity = _unitOfWork.JobAd.GetById(id);
            // Output object id on the console
            _logger.LogInformation($"Get JobAd with Id: {id} from database.");

            // Removes the passed record of the JobAd table in memory.
            _unitOfWork.JobAd.Remove(entity);
            // Writes the new status of the data record to the JobAd table.
            _unitOfWork.CompleteAsync();
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

            // Create a new record of the JobAd table in memory.
            _unitOfWork.JobAd.Insert(job);
            // Write the record in memory to the JobAd table in the database.
            _unitOfWork.CompleteAsync();
        }
    }
}
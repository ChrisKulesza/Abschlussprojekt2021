using Abschlussprojekt2021.Data;
using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task OnGetAsync()
        {
            JobAds = await _repository.GetAllAsync();
        }

        public void OnPostDelete()
        {
            System.Console.WriteLine("OnPostDelete");
        }
    }
}
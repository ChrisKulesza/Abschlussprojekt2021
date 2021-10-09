using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Abschlussprojekt2021.Areas.Identity.IdentityHostingStartup))]
namespace Abschlussprojekt2021.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
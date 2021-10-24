using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DataAccess.EFCore.Data
{
    /// <summary>
    /// Generates initial data records as soon as the corresponding table in the database is empty.
    /// </summary>
    public class AppDbInitializer
    {
        /// <summary>
        /// Creates records in the database in the <see cref="JobAd"/>s table if none exist.
        /// </summary>
        /// <param name="applicationBuilder">Provides the mechanisms to configure an application's request pipeline.</param>
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // add JobAd Data to Database
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Make the database context available.
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                // Check whether the table JobAds in the database contains data records.
                if (!context.JobAds.Any())
                {
                    // If there are no records then create the following.
                    context.JobAds.AddRange(new JobAd
                    {
                        Name = ".NET Junior Anwendungsentwickler (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = ".NET, Razor Pages, MS Azure Cloud Services, Visual Studio, Git",
                        Region = "Köln",
                        StartDate = DateTime.Parse("2021-12-01"),

                    }, 
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    },
                    new JobAd
                    {
                        Name = "Java Web Developer (m/w/d)",
                        Position = "Anwendungsentwickler",
                        Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
                        MainSkills = "abgeschlossenes Studium der Informatik, fundierte Kenntnisse der Softwareentwicklung (Java, Javascript)",
                        Region = "Köln, München, Berlin",
                        StartDate = DateTime.Parse("2021-12-01"),
                    });
                }

                context.SaveChanges();
            }
        }
    }
}

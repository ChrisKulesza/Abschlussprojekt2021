using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Abschlussprojekt2021.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // add JobAd Data to Database
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                // check if table in database is empty, if empty then populate following data
                if (!context.JobAds.Any())
                {
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

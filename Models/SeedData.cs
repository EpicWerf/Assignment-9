using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_9.Models
{
    //make some seed data to make sure the DB builds correctly 
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            //grab an instance of our CharitDbContext using a scoped version of it
            MovieDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            //if there are any pending migrations, migrate!
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if there is nothing in the database yet...
            if (!context.Movies.Any())
            {
                //then add all this stuff:
                context.Movies.AddRange(
                new Movie
                {
                    Category = "Test",
                    Title = "Test",
                    Year = "9999",
                    Director = "Test",
                    Rating = "Test",
                    Edited = false,
                    LentTo = "Test",
                    Notes = "Test"
                }

                );

                //go write this to the database
                context.SaveChanges();
            }
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelBookStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            StoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project
                    {
                        Title = "Les Miserables", 
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439", 
                        Classification = "Fiction",
                        Category = "Classic", 
                        Price = 9.95,
                        NumOfPages = 1488
                    },

                    new Project
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns", 
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        NumOfPages = 944
                    },

                    new Project
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        NumOfPages = 832
                    },

                    new Project
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C.", 
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        NumOfPages = 864
                    },

                    new Project
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        NumOfPages = 528
                    },

                    new Project
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        NumOfPages = 288
                    },

                    new Project
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        NumOfPages = 304
                    },

                    new Project
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael", 
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        NumOfPages = 240
                    },

                    new Project
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        NumOfPages = 400
                    },

                    new Project
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        NumOfPages = 642
                    },

                    new Project
                    {
                        Title = "The Good Neighbor",
                        AuthorFirst = "Maxwell",
                        AuthorLast = "King",
                        Publisher = "ABRAMS",
                        ISBN = "978-1419735165",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 15.99,
                        NumOfPages = 320
                    },

                    new Project
                    {
                        Title = "Harry Potter and the Sorcerer's Stone",
                        AuthorFirst = "J.K.",
                        AuthorLast = "Rowling",
                        Publisher = "Scholastic, Inc.",
                        ISBN = "978-1338596700",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 29.99,
                        NumOfPages = 368
                    },

                    new Project
                    {
                        Title = "The Infinite Atonement",
                        AuthorFirst = "Tad",
                        AuthorMiddle = "R.",
                        AuthorLast = "Callister",
                        Publisher = "Deseret Book Company",
                        ISBN = "978-1629726878",
                        Classification = "Non-Fiction",
                        Category = "Religious",
                        Price = 10.00,
                        NumOfPages = 720
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

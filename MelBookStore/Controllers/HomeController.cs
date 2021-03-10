using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
// Simple way to query
using System.Linq;
using System.Threading.Tasks;
using MelBookStore.Models;
using MelBookStore.Models.ViewModels; 

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private iStoreRepository _repository;
        // Declare variable for how many items to display per page
        public int PageSize = 5;

        // the dataset is passed in at run time when the home controller (constructor) is called for the first time. It gets the gets the repository passed in with the dataset. 
        public HomeController(ILogger<HomeController> logger, iStoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // default page is set to 1 & the option to view the category
        public IActionResult Index(string category, int pageNum = 1)
        {
            // We set the projects variable equal to the _repository which has been created by the iStoreRepository, which has been built form the efStoreRepository, which has been built from the StoreDbContext. 
            return View(new ProjectListViewModel
            {
                // Go to the repository to the projects table then do this stuff. 
                Projects = _repository.Projects
                    // Where the thing you want to filter by is = to the thing that has been selected 
                    .Where(p => category == null || p.Category == category)
                    // Order by the BookId
                    .OrderBy(p => p.BookID)
                    // Skip the page - 1 multiplied by the items per page
                    .Skip((pageNum - 1) * PageSize)
                    // Display 
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Projects.Count() :
                        _repository.Projects.Where(x => x.Category == category).Count()
                },

                // The current category in our object is = whatever category has been selected
                Category = category
            }); ;

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

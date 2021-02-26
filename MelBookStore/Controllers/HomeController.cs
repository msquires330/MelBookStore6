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

        public HomeController(ILogger<HomeController> logger, iStoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(int page = 1)
        {
            return View(new ProjectListViewModel
            {
                Projects = _repository.Projects
                    // Order by the BookId
                    .OrderBy(p => p.BookID)
                    // Skip the page - 1 multiplied by the items per page
                    .Skip((page - 1) * PageSize)
                    // Display 
                    .Take(PageSize)
                    , 
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page, 
                    ItemsPerPage = PageSize, 
                    TotalNumItems = _repository.Projects.Count()
                }
            });

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

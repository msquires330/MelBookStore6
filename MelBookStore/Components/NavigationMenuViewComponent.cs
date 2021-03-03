using MelBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelBookStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent 
    {
        private iStoreRepository repository;
        public NavigationMenuViewComponent (iStoreRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Projects
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}

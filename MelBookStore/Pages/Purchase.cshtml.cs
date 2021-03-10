using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelBookStore.Infrastructure;
using MelBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MelBookStore.Pages
{
    // inherited from the Page Model 
    public class PurchaseModel : PageModel

    {
        // Bring in an iStoreRepository 
        private iStoreRepository repository;

        // Constructor so the repository gets set 
        public PurchaseModel(iStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        // Properties 
        public Cart Cart{get; set;}
        public string ReturnUrl { get; set; }

        // Methods
        public void OnGet(string returnUrl)
        {
            // if url is null then just set it to /
            ReturnUrl = returnUrl ?? "/";
            // Needs to be GetJson because this is the OnGet method
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Project project = repository.Projects.FirstOrDefault(p => p.BookID == bookId);

            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(project, 1);

            // Needs to be SetJson because this is the OnPost method
            // HttpContext.Session.SetJson("cart", Cart);
            // the second returnUrl is the parameter 
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        // Remove Button action 
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Project.BookID == bookId).Project);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}

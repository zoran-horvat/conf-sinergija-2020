using System.Collections.Generic;
using System.Linq;
using Demo.Infrastructure;
using Demo.Models.Content;
using Demo.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class IndexModel : PageModel
    {
        private ISecureContext<Product> DbContext { get; }

        [BindProperty] public string NewProductName { get; set; } = string.Empty;
        public IEnumerable<Product> AllProducts { get; private set; } = Enumerable.Empty<Product>();

        public IndexModel(ISecureContextFactory<Product, UserRef> dbContextFactory)
        {
            this.DbContext = dbContextFactory.Create(this.GetAuthenticatedUser);
        }

        public void OnGet()
        {
            this.AllProducts = this.DbContext.QueryAll<Product>().ToList();
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(this.NewProductName))
            {
                this.DbContext.Add(new Product(0, this.NewProductName, this.GetAuthenticatedUser()));
                this.DbContext.SaveChanges();
            }
            return RedirectToPage("/Products/Index");
        }
    }
}

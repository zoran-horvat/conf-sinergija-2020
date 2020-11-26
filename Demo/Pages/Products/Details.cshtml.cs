using Demo.Infrastructure;
using Demo.Models.Content;
using Demo.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private ISecureContext<Product> DbContext { get; }

        [BindProperty]
        public int ProductId { get; set; }
        public Product Product { get; private set; }

        public DetailsModel(ISecureContextFactory<Product, UserRef> dbContextFactory)
        {
            this.DbContext = dbContextFactory.Create(this.GetAuthenticatedUser);
        }

        public void OnGet(int productId)
        {
            this.Product = this.DbContext.Find<Product>(productId);
        }
    }
}

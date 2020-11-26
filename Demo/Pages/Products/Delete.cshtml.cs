using System.Linq;
using System.Threading.Tasks;
using Demo.Infrastructure;
using Demo.Models.Content;
using Demo.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private ISecureContext<Product> DbContext { get; }

        public DeleteModel(ISecureContextFactory<Product, UserRef> dbContextFactory)
        {
            this.DbContext = dbContextFactory.Create(this.GetAuthenticatedUser);
        }

        public IActionResult OnPost(int productId)
        {
            if (this.DbContext.Find<Product>(productId) is Product toDelete)
            {
                this.DbContext.Remove(toDelete);
                this.DbContext.SaveChanges();
            }
            return RedirectToPage("/Products/Index");
        }
    }
}

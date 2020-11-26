using Demo.Models.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Security.Claims;

namespace Demo.Pages
{
    public static class PageUtilities
    {
        public static UserRef GetAuthenticatedUser(this PageModel page) =>
            new UserRef(page.HttpContext.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
    }
}

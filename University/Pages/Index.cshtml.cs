using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace University.Pages
{
    public class IndexModel : PageModel
    {
     
        public Task OnGetAsync()
        {
            return Task.CompletedTask;
        }
    }
}

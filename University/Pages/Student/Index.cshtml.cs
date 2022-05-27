using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University.DataAccess;
using University.Entities;

namespace University.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly University.DataAccess.UniversityContext _context;

        public IndexModel(University.DataAccess.UniversityContext context)
        {
            _context = context;
        }

        public IList<Entities.Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly University.DataAccess.UniversityContext _context;

        public DetailsModel(University.DataAccess.UniversityContext context)
        {
            _context = context;
        }

      public Entities.Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }
    }
}

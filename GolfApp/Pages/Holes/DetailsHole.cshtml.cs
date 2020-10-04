using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfApp.Data;
using GolfApp.Models;

namespace GolfApp.Pages.Holes
{
    public class DetailsHoleModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public DetailsHoleModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        public Hole Hole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hole = await _context.Holes.Include(h => h.Course).FirstOrDefaultAsync(m => m.HoleId == id);

            if (Hole == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

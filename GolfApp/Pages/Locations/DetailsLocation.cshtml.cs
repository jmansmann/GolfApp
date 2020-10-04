using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfApp.Data;
using GolfApp.Models;

namespace GolfApp.Pages.Locations
{
    public class DetailsLocationModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public DetailsLocationModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        public Location Location { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = await _context.Locations.FirstOrDefaultAsync(m => m.LocationId == id);

            ViewData["Courses"] = await _context.Courses.Where(c => c.LocationId == id).ToListAsync<Course>();
            if (Location == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

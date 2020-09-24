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
        private readonly GolfApp.Data.GolfAppCourseContext _context;

        public DetailsLocationModel(GolfApp.Data.GolfAppCourseContext context)
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

            Location = await _context.Location.FirstOrDefaultAsync(m => m.LocationId == id);

            ViewData["Courses"] = await _context.Course.Where(c => c.LocationId == id).ToListAsync<Course>();
            if (Location == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

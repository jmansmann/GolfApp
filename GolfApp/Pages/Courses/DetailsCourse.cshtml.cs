using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfApp.Data;
using GolfApp.Models;

namespace GolfApp.Pages.Courses
{
    public class DetailsCourseModel : PageModel
    {
        private readonly GolfApp.Data.GolfAppCourseContext _context;

        public DetailsCourseModel(GolfApp.Data.GolfAppCourseContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Course
                .Include(c => c.Location).Include(c => c.Holes).FirstOrDefaultAsync(m => m.CourseId == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

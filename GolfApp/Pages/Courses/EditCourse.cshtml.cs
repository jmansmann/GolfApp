using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfApp.Data;
using GolfApp.Models;

namespace GolfApp.Pages.Courses
{
    public class EditCourseModel : PageModel
    {
        private readonly GolfApp.Data.GolfAppCourseContext _context;

        public EditCourseModel(GolfApp.Data.GolfAppCourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Course
                .Include(c => c.Location).FirstOrDefaultAsync(m => m.CourseId == id);

            if (Course == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "UniqueName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var courseToUpdate = await _context.Course.FindAsync(id);
            if (courseToUpdate == null)
            {
                return NotFound();
            }


            try
            {
                if (await TryUpdateModelAsync<Course>(courseToUpdate, "course",
                c => c.Name, c => c.Par, c => c.LocationId, c => c.DateFounded, c => c.Type))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./IndexCourse");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.CourseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./IndexCourse");
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}

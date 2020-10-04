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
    public class DeleteCourseModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public DeleteCourseModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses.AsNoTracking()
                .Include(c => c.Location).Include(c => c.Holes).FirstOrDefaultAsync(m => m.CourseId == id);

            if (Course == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToDelete = await _context.Courses.Where(c => c.CourseId == id).Include(c => c.Holes).ToListAsync();

            if (courseToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _context.Courses.Remove(courseToDelete.FirstOrDefault());
                await _context.SaveChangesAsync();
                return RedirectToPage("./IndexCourse");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./DeleteCourse",
                                     new { id, saveChangesError = true });
            }
        }
    }
}

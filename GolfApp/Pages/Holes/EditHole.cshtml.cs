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

namespace GolfApp.Pages.Holes
{
    public class EditHoleModel : PageModel
    {
        private readonly GolfApp.Data.GolfAppCourseContext _context;

        public EditHoleModel(GolfApp.Data.GolfAppCourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hole Hole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hole = await _context.Hole.FirstOrDefaultAsync(m => m.HoleId == id);

            var courses = await _context.Course.Select(c => new
            { 
                c.CourseId,
                c.Name
            }).ToListAsync();

            ViewData["Courses"] = new SelectList(courses, "CourseId", "Name");

            if (Hole == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var holeToUpdate = await _context.Hole.FindAsync(id);

            if (holeToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                if (await TryUpdateModelAsync<Hole>(holeToUpdate, "hole",
                    h => h.Par, h => h.Num, h => h.CourseId))
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./IndexHole");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoleExists(Hole.HoleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Page();
        }

        private bool HoleExists(int id)
        {
            return _context.Hole.Any(e => e.HoleId == id);
        }
    }
}

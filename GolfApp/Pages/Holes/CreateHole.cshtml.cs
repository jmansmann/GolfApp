using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfApp.Data;
using GolfApp.Models;
using System.Runtime.InteropServices.ComTypes;

namespace GolfApp.Pages.Holes
{
    public class CreateHoleModel : PageModel
    {
        private readonly GolfApp.Data.GolfAppCourseContext _context;

        public CreateHoleModel(GolfApp.Data.GolfAppCourseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var courses = _context.Course.ToList();
            ViewData["Courses"] = new SelectList(courses, "CourseId", "Name");
            return Page();
        }

        [BindProperty]
        public Hole Hole { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var emptyHole = new Hole();

            if (await TryUpdateModelAsync<Hole>(emptyHole, "hole",
                h => h.Par, h => h.CourseId, h => h.Num))
            {
                _context.Hole.Add(emptyHole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexHole");
        }
    }
}

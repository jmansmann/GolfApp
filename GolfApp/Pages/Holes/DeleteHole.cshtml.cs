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
    public class DeleteHoleModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public DeleteHoleModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hole Hole { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hole = await _context.Holes.FirstOrDefaultAsync(m => m.HoleId == id);

            if (Hole == null)
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

            Hole = await _context.Holes.FindAsync(id);

            if (Hole == null)
            {
                return NotFound();
            }

            try
            {
                _context.Holes.Remove(Hole);
                await _context.SaveChangesAsync();
                return RedirectToPage("./IndexHole");

            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction("./DeleteHole",
                                 new { id, saveChangesError = true });
            }

        }
    }
}

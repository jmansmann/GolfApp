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

namespace GolfApp.Pages.Golfers
{
    public class EditModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public EditModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Golfer Golfer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Golfer = await _context.Golfers.FirstOrDefaultAsync(m => m.GolferId == id);

            if (Golfer == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Golfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GolferExists(Golfer.GolferId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./IndexGolfer");
        }

        private bool GolferExists(int id)
        {
            return _context.Golfers.Any(e => e.GolferId == id);
        }
    }
}

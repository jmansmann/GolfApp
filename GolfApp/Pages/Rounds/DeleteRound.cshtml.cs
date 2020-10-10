using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfApp.Data;
using GolfApp.Models;

namespace GolfApp.Pages.Rounds
{
    public class DeleteModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public DeleteModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Round Round { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Round = await _context.Rounds
                .Include(r => r.CoursePlayed).FirstOrDefaultAsync(m => m.RoundId == id);

            if (Round == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Round = await _context.Rounds.FindAsync(id);

            if (Round != null)
            {
                _context.Rounds.Remove(Round);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexRound");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfApp.Data;
using GolfApp.Models;

namespace GolfApp.Pages.Rounds
{
    public class CreateModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public CreateModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        public IQueryable<Hole> Holes { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Golfers"] = new SelectList(_context.Golfers, "GolferId", "FullName");
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Name");
            return Page();
        }

        [BindProperty]
        public Round Round { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rounds.Add(Round);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexRound");
        }
    }
}

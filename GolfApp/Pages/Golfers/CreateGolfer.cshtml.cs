using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfApp.Data;
using GolfApp.Models;

namespace GolfApp.Pages.Golfers
{
    public class CreateModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public CreateModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Sexes"] = new SelectList(Enum.GetValues(typeof(Sex)).Cast<Sex>());
            return Page();
        }

        [BindProperty]
        public Golfer Golfer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Golfers.Add(Golfer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexGolfer");
        }
    }
}

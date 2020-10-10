using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfApp.Data;
using GolfApp.Models;

namespace GolfApp.Pages.Golfers
{
    public class DetailsModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public DetailsModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

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
    }
}

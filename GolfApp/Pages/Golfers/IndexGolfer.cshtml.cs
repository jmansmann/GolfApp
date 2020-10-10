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
    public class IndexModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public IndexModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        public IList<Golfer> Golfer { get;set; }

        public async Task OnGetAsync()
        {
            Golfer = await _context.Golfers.ToListAsync();
        }
    }
}

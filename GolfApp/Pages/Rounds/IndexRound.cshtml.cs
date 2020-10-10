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
    public class IndexModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public IndexModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        public IList<Round> Round { get;set; }

        public async Task OnGetAsync()
        {
            Round = await _context.Rounds
                .Include(r => r.CoursePlayed).Include(r => r.Golfer).ToListAsync();
        }
    }
}

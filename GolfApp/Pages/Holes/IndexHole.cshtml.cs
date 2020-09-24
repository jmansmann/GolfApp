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
    public class IndexHoleModel : PageModel
    {
        private readonly GolfApp.Data.GolfAppCourseContext _context;

        public IndexHoleModel(GolfApp.Data.GolfAppCourseContext context)
        {
            _context = context;
        }

        public IList<Hole> Hole { get;set; }

        public async Task OnGetAsync()
        {
            Hole = await _context.Hole.Include(h => h.Course).ToListAsync();
        }
    }
}

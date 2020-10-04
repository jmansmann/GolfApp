using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfApp.Data;
using GolfApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace GolfApp.Pages
{
    public class AboutModel : PageModel
    {
        private readonly CourseContext _context;
        public AboutModel(CourseContext context)
        {
            _context = context;   
        }
        public IList<CourseDateFoundedGroup> Courses { get; set; }

        public async Task OnGet()
        {
            IQueryable<CourseDateFoundedGroup> data =
                from c in _context.Courses
                group c by c.DateFounded into dateGroup
                select new CourseDateFoundedGroup()
                {
                    DateFounded = dateGroup.Key,
                    CourseCount = dateGroup.Count()
                };

            Courses = await data.AsNoTracking().ToListAsync();
        }
    }
}

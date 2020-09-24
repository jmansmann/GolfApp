using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfApp.Data;
using GolfApp.Models;
using GolfApp.Util;

namespace GolfApp.Pages.Courses
{
    public class IndexCourseModel : PageModel
    {
        private readonly GolfApp.Data.GolfAppCourseContext _context;

        public IndexCourseModel(GolfApp.Data.GolfAppCourseContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string LocationSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Course> Courses { get; set; }


        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Course> coursesIQ = _context.Course;

            if(!string.IsNullOrWhiteSpace(searchString))
            {
                coursesIQ = coursesIQ.Where(c => c.Name.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    coursesIQ = coursesIQ.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    coursesIQ = coursesIQ.OrderBy(s => s.DateFounded);
                    break;
                case "date_desc":
                    coursesIQ = coursesIQ.OrderByDescending(s => s.DateFounded);
                    break;
                default:
                    coursesIQ = coursesIQ.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;
            Courses = await PaginatedList<Course>.CreateAsync(coursesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

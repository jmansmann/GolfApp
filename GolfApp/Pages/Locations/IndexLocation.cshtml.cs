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

namespace GolfApp.Pages.Locations
{
    public class IndexLocationModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public IndexLocationModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        public string CityNameSort { get; set; }
        //public string NumCoursesSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }

        public PaginatedList<Location> Locations { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            CityNameSort = string.IsNullOrWhiteSpace(sortOrder) ? "name_desc" : "";
            //NumCoursesSort = sortOrder == "Courses" ? "courses_desc" : "Courses";

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Location> locationIQ = _context.Locations;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                locationIQ = locationIQ.Where(l => l.City.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    locationIQ = locationIQ.OrderByDescending(s => s.City);
                    break;
                default:
                    locationIQ = locationIQ.OrderBy(s => s.City);
                    break;
            }

            int pageSize = 3;
            Locations = await PaginatedList<Location>.CreateAsync(locationIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfApp.Data;
using GolfApp.Models;
using GolfApp.Util;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GolfApp.Pages.Courses
{
    public class CreateCourseModel : PageModel
    {
        private readonly GolfApp.Data.CourseContext _context;

        public CreateCourseModel(GolfApp.Data.CourseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var displayLocations = _context.Locations.Select(loc =>
                                                            new SelectListItem
                                                            {
                                                                Value = loc.LocationId.ToString(),
                                                                Text = loc.City + ", " + loc.ZipCode
                                                            });
            ViewData["Locations"] = displayLocations;

            //var enumDisplayList = new List<string>();
            //var enumList = Enum.GetValues(typeof(CourseType)).Cast<CourseType>();
            //foreach (var e in enumList)
            //{
            //    enumDisplayList.Add(CommonUtils.GetAttribute<DisplayAttribute>(e).Name);
            //}
            
            ViewData["Types"] = new SelectList(Enum.GetValues(typeof(CourseType)).Cast<CourseType>());

            var holes = _context.Holes.Select(h => new
            {
                CourseId = h.CourseId,
                HoleId = h.HoleId,
                Num = h.Num,
                Par = h.Par
            }).Where(h => !h.CourseId.HasValue).ToList();

            ViewData["Holes"] = new MultiSelectList(holes, "HoleId", "Num");
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }
        [BindProperty]
        public int HoleId { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyCourse = new Course();


            //var holeToUpdate = await _context.Hole.FindAsync(HoleId);
            //if (await TryUpdateModelAsync<Hole>(holeToUpdate, "hole", h=> h.CourseId))

            if (await TryUpdateModelAsync<Course>(emptyCourse, "course",
                c => c.Name, c => c.Par, c => c.LocationId, c => c.DateFounded, c => c.Type))
            {
                _context.Courses.Add(Course);
                await _context.SaveChangesAsync();

                return RedirectToPage("./IndexCourse");
            }

            //_context.Course.Add(Course);
            //await _context.SaveChangesAsync();

            return Page();

        }
    }
}

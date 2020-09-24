using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GolfApp.Data;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using GolfApp.Util;
using System.Collections.Generic;

namespace GolfApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GolfAppCourseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GolfAppCourseContext>>()))
            {
                if (context.Course.Any())
                    return;
                var locations = new Location[]
                {
                    new Location
                    {
                        Country = "USA",
                        State = "PA",
                        City = "Philadelphia",
                        ZipCode = 19103
                    },
                    new Location
                    {
                        Country = "USA",
                        State = "PA",
                        City = "Pittsburgh",
                        ZipCode = 15213
                    },
                    new Location
                    {
                        Country = "USA",
                        State = "PA",
                        City = "Pittsburgh",
                        ZipCode = 15068
                    },
                    new Location
                    {
                        Country = "USA",
                        State = "PA",
                        City = "Philadelphia",
                        ZipCode = 19130
                    },
                    new Location
                    {
                        Country = "USA",
                        State = "NY",
                        City = "New York City",
                        ZipCode = 17890
                    },
                    new Location
                    {
                        Country = "USA",
                        State = "NJ",
                        City = "Newark",
                        ZipCode = 18909
                    }
                };
                context.AddRange(locations);
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course {Name = "Cabin Greens", LocationId = 1, Type = CourseType.Executive, Par = 72, DateFounded = DateTime.Parse("02/12/1989")},
                    new Course {Name = "Saxonburg Golf Club", LocationId = 2, Type = CourseType.Links, Par = 72, DateFounded = DateTime.Parse("03/17/1949")},
                    new Course {Name = "Sewickly Golf Club", LocationId = 3, Type = CourseType.Links, Par = 72, DateFounded = DateTime.Parse("12/22/1933")},
                    new Course {Name = "Buffalo Golf Course", LocationId = 4, Type = CourseType.PitchAndPutt, Par = 36, DateFounded = DateTime.Parse("10/02/1889")},
                    new Course {Name = "Fox Chapel Country Club", LocationId = 3, Type = CourseType.Links, Par = 72, DateFounded = DateTime.Parse("05/05/1895")},
                };
                context.AddRange(courses);
                context.SaveChanges();
                InitializeSomeHoles(context);
                context.SaveChanges();
                //InitializeLocations(context);
                //context.SaveChanges();
                //InitializeCourses(context);
                //context.SaveChanges();
            }
        }

        private static void InitializeSomeHoles(GolfAppCourseContext context)
        {
            if (context.Hole.Any())
            {
                return;
            }

            context.Hole.AddRange(
                new Hole
                {
                    Num = 1,
                    Par = 3
                },
                new Hole
                {
                    Num = 2,
                    Par = 4
                },
                new Hole
                {
                    Num = 3,
                    Par = 5
                },
                new Hole
                {
                    Num = 4,
                    Par = 4
                },
                new Hole
                {
                    Num = 5,
                    Par = 4
                },
                new Hole
                {
                    Num = 6,
                    Par = 3
                },
                new Hole
                {
                    Num = 7,
                    Par = 5
                },
                new Hole
                {
                    Num = 8,
                    Par = 5
                },
                new Hole
                {
                    Num = 9,
                    Par = 3
                },
                new Hole
                {
                    Num = 1,
                    Par = 3
                },
                new Hole
                {
                    Num = 2,
                    Par = 4
                },
                new Hole
                {
                    Num = 3,
                    Par = 5
                },
                new Hole
                {
                    Num = 4,
                    Par = 4
                },
                new Hole
                {
                    Num = 5,
                    Par = 4
                },
                new Hole
                {
                    Num = 6,
                    Par = 3
                },
                new Hole
                {
                    Num = 7,
                    Par = 5
                },
                new Hole
                {
                    Num = 8,
                    Par = 5
                },
                new Hole
                {
                    Num = 9,
                    Par = 3
                },
                new Hole
                {
                    Num = 1,
                    Par = 3
                },
                new Hole
                {
                    Num = 2,
                    Par = 4
                },
                new Hole
                {
                    Num = 3,
                    Par = 4
                },
                new Hole
                {
                    Num = 4,
                    Par = 5
                });
        }


        private static void InitializeLocations (GolfAppCourseContext context)
        {
            if (context.Location.Any())
            {
                return;
            }

            context.Location.AddRange(
                new Location
                {
                    Country = "USA",
                    State = "PA",
                    City = "Philadelphia",
                    ZipCode = 19103
                },
                new Location
                {
                    Country = "USA",
                    State = "PA",
                    City = "Pittsburgh",
                    ZipCode = 15213
                },
                new Location
                {
                    Country = "USA",
                    State = "PA",
                    City = "Pittsburgh",
                    ZipCode = 15068
                },
                new Location
                {
                    Country = "USA",
                    State = "PA",
                    City = "Philadelphia",
                    ZipCode = 19130
                },
                new Location
                {
                    Country = "USA",
                    State = "NY",
                    City = "New York City",
                    ZipCode = 17890
                },
                new Location
                {
                    Country = "USA",
                    State = "NJ",
                    City = "Newark",
                    ZipCode = 18909
                }
            );
        }
        private static void InitializeCourses(GolfAppCourseContext context)
        {
            // Look for any movies.
            if (context.Course.Any())
            {
                return;   // DB has been seeded
            }

            var locationIdList = context.Location.Select(x => x.LocationId).ToList();
            var holeList = (from c in context.Hole select c).ToList();

            context.Course.AddRange(
                new Course
                {
                    Name = "Rusty Jawn",
                    Par = 83,
                    Type = CourseType.Executive,
                    DateFounded = DateTime.Parse("02/12/1989"),
                    LocationId = CommonUtils.GetRandomObject<int>(locationIdList),
                   // Holes = new List<Hole>() { CommonUtils.GetRandomObject<Hole>(holeList), CommonUtils.GetRandomObject<Hole>(holeList) }
                },

                new Course
                {
                    Name = "Musty Jawn",
                    Par = 85,
                    Type = CourseType.Executive,
                    DateFounded = DateTime.Parse("05/17/1961"),
                    LocationId = CommonUtils.GetRandomObject<int>(locationIdList),
                   // Holes = new List<Hole>() { CommonUtils.GetRandomObject<Hole>(holeList), CommonUtils.GetRandomObject<Hole>(holeList) }
                },

                new Course
                {
                    Name = "Tough Jawn",
                    Par = 89,
                    Type = CourseType.Links,
                    DateFounded = DateTime.Parse("12/21/1923"),
                    LocationId = CommonUtils.GetRandomObject<int>(locationIdList),
                   // Holes = new List<Hole>() { CommonUtils.GetRandomObject<Hole>(holeList), CommonUtils.GetRandomObject<Hole>(holeList) }
                },

                new Course
                {
                    Name = "Easy Jawn",
                    Par = 9,
                    Type = CourseType.PitchAndPutt,
                    DateFounded = DateTime.Parse("10/10/1900"),
                    LocationId = CommonUtils.GetRandomObject<int>(locationIdList),
                    //Holes = new List<Hole>() { CommonUtils.GetRandomObject<Hole>(holeList), CommonUtils.GetRandomObject<Hole>(holeList) }
                }
            );
        }


    }
}
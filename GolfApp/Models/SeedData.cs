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
            using (var context = new CourseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CourseContext>>()))
            {
                if (context.Courses.Any())
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
                InitializeRoundsOfGolf(context);
                context.SaveChanges();
                IntializeGolfers(context);
                context.SaveChanges();
                //InitializeLocations(context);
                //context.SaveChanges();
                //InitializeCourses(context);
                //context.SaveChanges();
            }
        }

        private static void InitializeRoundsOfGolf(CourseContext context)
        {
            if (context.Rounds.Any())
            {
                return;
            }
            var courseIdList = context.Courses.Select(c => c.CourseId).ToList();
            var golferIdList = context.Golfers.Select(g => g.GolferId).ToList();

            context.Rounds.AddRange(
                new Round
                {
                    DatePlayed = DateTime.Parse("09/23/2020"),
                    Score = 65,
                    CourseId = courseIdList.FirstOrDefault(),
                    GolferId = golferIdList.ElementAt(1)
                },
                new Round
                {
                    DatePlayed = DateTime.Parse("09/24/2020"),
                    Score = 70,
                    CourseId = courseIdList.ElementAt(1),
                    GolferId = golferIdList.ElementAt(1)
                },
                new Round
                {
                    DatePlayed = DateTime.Parse("09/25/2020"),
                    Score = 69,
                    CourseId = courseIdList.ElementAt(1),
                    GolferId = golferIdList.ElementAt(2)
                },
                new Round
                {
                    DatePlayed = DateTime.Parse("10/01/2020"),
                    Score = 80,
                    CourseId = courseIdList.ElementAt(2),
                    GolferId = golferIdList.ElementAt(2)
                },
                new Round
                {
                    DatePlayed = DateTime.Parse("10/02/2020"),
                    Score = 75,
                    CourseId = courseIdList.ElementAt(3),
                    GolferId = golferIdList.ElementAt(0)
                });
        }

        private static void IntializeGolfers(CourseContext context)
        {
            if (context.Golfers.Any())
            {
                return;
            }

            var roundsIdList = context.Rounds.Select(r => r.RoundId).ToList();

            context.Golfers.AddRange(
                new Golfer
                {
                    FirstName = "Jim",
                    LastName = "Mansmann",
                    Sex = Sex.Male,
                    //RoundsPlayed = context.Rounds.Where(r => r.RoundId == roundsIdList.FirstOrDefault()).ToList()
                },
                new Golfer
                {
                    FirstName = "Seth",
                    LastName = "Bowser",
                    Sex = Sex.Male,
                    //RoundsPlayed = context.Rounds.Where(r => r.RoundId == roundsIdList.ElementAt(2)).ToList()
                },
                new Golfer
                {
                    FirstName = "Kristen",
                    LastName = "Zulli",
                    Sex = Sex.Female,
                    //RoundsPlayed = context.Rounds.Where(r => r.RoundId == roundsIdList.ElementAt(3)).ToList()
                }
                );
        }

        private static void InitializeSomeHoles(CourseContext context)
        {
            if (context.Holes.Any())
            {
                return;
            }
            var courseIdList = context.Courses.Select(c => c.CourseId).ToList();
            context.Holes.AddRange(
                new Hole
                {
                    Num = 1,
                    Par = 3,
                    CourseId = courseIdList.ElementAt(1)
                },
                new Hole
                {
                    Num = 2,
                    Par = 4,
                    CourseId = courseIdList.ElementAt(1)
                },
                new Hole
                {
                    Num = 3,
                    Par = 5,
                    CourseId = courseIdList.ElementAt(1)
                },
                new Hole
                {
                    Num = 4,
                    Par = 4,
                    CourseId = courseIdList.ElementAt(1)
                },
                new Hole
                {
                    Num = 5,
                    Par = 4,
                    CourseId = courseIdList.ElementAt(1)
                },
                new Hole
                {
                    Num = 6,
                    Par = 3,
                    CourseId = courseIdList.ElementAt(1)
                },
                new Hole
                {
                    Num = 7,
                    Par = 5,
                    CourseId = courseIdList.ElementAt(1)
                },
                new Hole
                {
                    Num = 8,
                    Par = 5,
                    CourseId = courseIdList.ElementAt(1)
                },
                new Hole
                {
                    Num = 9,
                    Par = 3,
                    CourseId = courseIdList.ElementAt(1)
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


        private static void InitializeLocations (CourseContext context)
        {
            if (context.Locations.Any())
            {
                return;
            }

            context.Locations.AddRange(
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
        private static void InitializeCourses(CourseContext context)
        {
            // Look for any movies.
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }

            var locationIdList = context.Locations.Select(x => x.LocationId).ToList();
            var holeList = (from c in context.Holes select c).ToList();

            context.Courses.AddRange(
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
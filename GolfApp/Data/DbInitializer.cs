using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfApp.Models;
using GolfApp.Data;

namespace GolfApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(CourseContext context)
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
                IntializeGolfers(context);
                context.SaveChanges();
                InitializeRoundsOfGolf(context);
                context.SaveChanges();

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

    }
}

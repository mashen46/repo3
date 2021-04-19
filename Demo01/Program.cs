using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo01.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo01
{
    public class Program
    {

        public static void Main(string[] args)
        {
            using var context = new DemoContext();
            // //var serieA  = context.Leagues.Single(x => x.Name == "SerieA");
            // var serieB=new League
            // {
            //     Country = "Italy",
            //     Name = "Serie B"
            // };
            // var serieC = new League
            // {
            //     Country = "Italy",
            //     Name = "Serie C"
            // };
            // var milan = new Club
            // {
            //     Name = "AC Milan",
            //     City = "Milan",
            //     DateOfEstablishment =new DateTime( year:1899, month:12, day:16),
            //    // League=serieA
            // };
            // context.AddRange(serieB,serieC,milan);
            // //context.Leagues.AddRange(serieB,serieC);
            // //context.Leagues.AddRange(new List<League> {serieB,serieC});
            // var count = context.SaveChanges();
            // Console.WriteLine(count);
            // Country Like "%e%"
            // var italy="Italy";
            // var leagues =
            // context.Leagues.Where(x => x.Country == italy).ToList();
            //var leagues =
            // context.Leagues.Where(x => x.Country.Contains("e")).ToList();
            // var leagues2=(from lg in context.Leagues 
            // where lg.Country =="Italy"
            // select lg).ToList();
            // var first = context.Leagues
            // .SingleOrDefault(x =>
            //     x.Id == 2
            // );
            // var two =context.Leagues.Find(2);
            // Console.WriteLine(first?.Name);
            // Console.WriteLine(two?.Name);
            // var last=context.Leagues.OrderBy(x =>x.Id)
            // .LastOrDefault(x =>x.Name.Contains("e"));
            // var milan = context.Clubs.Single(x => x.Name == "AC Milan");
            // //调用删除方法
            // context.Clubs.Remove(milan);
            // context.Remove(milan);
            // context.Clubs.RemoveRange(milan,milan);
            // context.RemoveRange(milan,milan);
            // var count = context.SaveChanges();
            // Console.WriteLine(count);
            // var league = context.Leagues.First();
            // league.Name +="~";
            // var count = context.SaveChanges();
            // Console.WriteLine(count);
            // var leagues = context.Leagues.Skip(1).Take(3).ToList();
            // foreach(var league in leagues){
            //     league.Name += "~";
            // }
            // var count = context.SaveChanges();
            // Console.WriteLine(count);
            // var league = context.Leagues.AsNoTracking().First();
            // league.Name += "++";
            // context.Leagues.Update(league);
            // var count =context.SaveChanges();
            // Console.WriteLine(count);
            // var serieA = context.Leagues.Single(x => x.Name == "SerieA");
            // var jeventus = new Club{
            //     //League = serieA,
            //     Name = "Jeventus",
            //     City = "Torino",
            //     DateOfEstablishment = new DateTime(1987,12,18), 
            //     Players = new List<Player>{
            //         new Player{
            //             Name = "C .Ronoldo",
            //             DateBirth = new DateTime(1985,2,7)
            //         }
            //     }              
            // };
            // context.Clubs.Add(jeventus);
            // int count = context.SaveChanges();
            // Console.WriteLine(count);
            
            // var jeventus = context.Clubs.Single(x => x.Name == "Jeventus");
            // jeventus.Players.Add(new Player
            // {
            //     Name = "Ganzolo Higua",
            //     DateBirth = new DateTime(1988, 12, 03)
            // }
            // );
            // int count = context.SaveChanges();
            // Console.WriteLine(count);
            // var jeventus = context.Clubs.Single(x => x.Name == "Jeventus");
            // jeventus.Players.Add(
            //     new Player{
            //         Name = "Mbb Light",
            //         DateBirth = new DateTime(1987, 09, 03)
            //     }
            // );
            // using var newContext =new DemoContext();
            // newContext.Clubs.Attach(jeventus); 
            // var count = newContext.SaveChanges();
            // Console.WriteLine(count);
            // var resume = new Resume{
            //     PlayerId = 1,
            //     Description = "..."
            // };
            // context.Resumes.Add(resume);
            // int count=context.SaveChanges();
            // Console.WriteLine(count);
            //var clubs = context.Clubs.Include(x =>x.League).ToList();
            // var clubs = context.Clubs.Where(x => x.Id>0)
            // .Include(x => x.League)
            // .Include(x => x.Players)
            //     .ThenInclude(y => y.Resume)
            //     .Include(x => x.Players)
            //     .ThenInclude(y => y.GamePlayers)
            //         .ThenInclude(z => z.Game)
            // .FirstOrDefault();
            // var info = context.Clubs.Where(x => x.Id>0)
            //             .Select(x => new
            //             {
            //                 x.Id,
            //                 LeagueName = x.League.Name,
            //                 x.Name,
            //                 Players = x.Players
            //                 .Where(p => 
            //                 p.DateBirth > new DateTime(1980,01,01))
            //             }).ToList();
                // var info = context.Clubs.First();
                // context.Entry(info).Collection(x => x.Players)
                // .Query()
                // .Where(x => x.DateBirth > new DateTime(1987,09,12))
                // .Load();
                // context.Entry(info).Reference(x => x.League).Load();
                // var data = context.Clubs.Where(x =>
                // x.League.Name.Contains("e")
                // ).ToList();
                // var gameplayers = context.Set<GamePlayer>()
                // .Where(x => x.PlayerId>0)
                // .ToList();
            //   var player = context.Players
            //   .Include(x => x.Resume)
            //   .FirstOrDefault();
            //   player.Resume = new Resume{
            //       Description = "1234"
            //   };
            //     context.SaveChanges();
          var leagues = context.Leagues
                        .FromSqlRaw("SELECT * FROM dbo.Leagues")
                        .ToList();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

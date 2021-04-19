using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Demo01.Entities
{
    public class DemoContext :DbContext
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerClub> PlayerClubs { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamePlayer>().HasKey(x => new{x.PlayerId,x.GameId});
            modelBuilder.Entity<Resume>()
            .HasOne(x =>x.Player)
            .WithOne(x => x.Resume)
            .HasForeignKey<Resume>(x => x.PlayerId);
            modelBuilder.Entity<PlayerClub>()
                .HasNoKey()
                .ToView("PlayerClubView");
        }
        public static readonly ILoggerFactory ConsoleLoggerFatory =
        LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category,level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information)
                .AddConsole();
        });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(ConsoleLoggerFatory)
            .EnableSensitiveDataLogging()
            .UseSqlServer(@"server=.;database=Demo;uid=sa;pwd=pwd@1234");
        }
    }
    
}
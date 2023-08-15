using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 3, Nickname = "Red Squirrel", ImageUrl="https://www.naturescampsites.com/app/uploads/2021/01/39327DC1-AB40-4B6A-B8BB-3758ADEC5215.jpeg"},
            new Campsite {Id = 3, CampsiteTypeId = 4, Nickname = "White-Tailed Deer", ImageUrl="https://bearfoottheory.com/wp-content/uploads/2018/05/Leave-No-Trace-campsite-tent.jpg"},
            new Campsite {Id = 4, CampsiteTypeId = 2, Nickname = "Great Tortoise", ImageUrl="https://www.tripsavvy.com/thmb/ZDXfkFTwAcC49Whakd2rlbwAysA=/2119x1414/filters:no_upscale():max_bytes(150000):strip_icc()/GettyImages-1016296534-020ab0eaccc847618acc38804a8a9cd2.jpg"},
            new Campsite {Id = 5, CampsiteTypeId = 1, Nickname = "Coyote Cross", ImageUrl="https://photos.thedyrt.com/photo/117425/media/california-atwell-mill_65e1e419b13a7d4d6424853413973488.jpg"},
            new Campsite {Id = 6, CampsiteTypeId = 4, Nickname = "Indian Moss", ImageUrl="https://explorationsolo.com/wp-content/uploads/2022/01/Jacob-Branch-Primitive-Campsite.jpg"},
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Richard", LastName = "Allan", Email = "richallan68@yahoo.com"}
        });
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 4, UserProfileId = 1, CheckinDate = DateTime.Today, CheckoutDate = DateTime.Today.AddDays(7)}
        });
    }
}
using BookingApp.Entity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;

namespace BookingApp.DataContext
{
    public class BookingAppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public BookingAppDbContext()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public BookingAppDbContext(DbContextOptions<BookingAppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentCardInfo> PaymentCardInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>().HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<UserRole>(
                    x => x.HasOne(x => x.Role)
                    .WithMany().HasForeignKey(x => x.RoleID),
                    x => x.HasOne(x => x.User)
                   .WithMany().HasForeignKey(x => x.UserID));

            builder.Entity<Payment>()
                .HasOne(p => p.PaymentCardInfo)
                .WithOne(c => c.Payment)
                .HasForeignKey<PaymentCardInfo>(c => c.PaymentID);

            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedRooms(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        private void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    Password = "Admin007",
                    IsActive = true,
                },
                new User
                {
                    UserID = 2,
                    Email = "customer@gmail.com",
                    UserName = "Customer",
                    Password = "Customer007",
                    IsActive = true
                }
            );

            builder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserID = 1,
                    RoleID = 1
                },
                new UserRole
                {
                    UserID = 2,
                    RoleID = 2
                }
            );
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
            new Role
            {
                RoleID = 1,
                RoleName = "Admin"
            },
            new Role
            {
                RoleID = 2,
                RoleName = "Customer"
            });
        }

        private void SeedRooms(ModelBuilder builder)
        {
            builder.Entity<Room>().HasData(
                new Room
                {
                    RoomID = 1,
                    Description = "Single room",
                    IsAvailable = true,
                    Price = 120
                },
                new Room
                {
                    RoomID = 2,
                    Description = "Delux room",
                    IsAvailable = true,
                    Price = 120
                },
                new Room
                {
                    RoomID = 3,
                    Description = "Family room",
                    IsAvailable = true,
                    Price = 120
                });
        }
    }
}

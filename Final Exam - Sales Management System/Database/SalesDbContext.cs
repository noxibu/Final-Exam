using Final_Exam___Sales_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final_Exam___Sales_Management_System.Database
{
    public class SalesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UsersInformation { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Image> Images { get; set; }


        public SalesDbContext(DbContextOptions<SalesDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(e => e.UserInformation)
                .WithOne(e => e.User)
                .HasForeignKey<UserInformation>(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<UserInformation>()
                .HasOne(e => e.Address)
                .WithOne(e => e.UserInformation)
                .HasForeignKey<Address>(e => e.UserInformationId)
                .IsRequired();

            modelBuilder.Entity<UserInformation>()
                .HasOne(e => e.ProfilePicture)
                .WithOne(e => e.UserInformation)
                .HasForeignKey<Image>(e => e.UserInformationId)
                .IsRequired();
        }
    }
}

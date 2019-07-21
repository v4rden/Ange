namespace Ange.Persistence
{
    using Application.Interfaces;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AngeDbContext : DbContext, IAngeDbContext
    {
        public AngeDbContext(DbContextOptions<AngeDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<UserRoom> UserRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AngeDbContext).Assembly);
        }
    }
}
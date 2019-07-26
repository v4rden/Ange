namespace Ange.Application.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IAngeDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<ChatMessage> ChatMessages { get; set; }
        DbSet<UserRoom> UserRooms { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
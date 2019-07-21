namespace Ange.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserRoomConfiguration : IEntityTypeConfiguration<UserRoom>
    {
        public void Configure(EntityTypeBuilder<UserRoom> builder)
        {
            builder.HasKey(ur => new {ur.UserId, ur.RoomId})
                .ForSqlServerIsClustered(false);

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.RecideRooms)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Room)
                .WithMany(r => r.Participants)
                .HasForeignKey(ur => ur.RoomId);
        }
    }
}
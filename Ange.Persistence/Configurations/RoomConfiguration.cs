namespace Ange.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.RoomCreator).IsRequired();
            builder.Property(x => x.Type).IsRequired();
        }
    }
}
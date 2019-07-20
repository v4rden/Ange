namespace Ange.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.RoomId).IsRequired();
            builder.Property(x => x.AuthorId).IsRequired();
            builder.Property(x => x.SentTime).IsRequired();
            builder.Property(x => x.LastModified);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.MessageText).IsRequired();

            builder.HasOne(c => c.Author)
                .WithMany(u => u.Messages)
                .HasForeignKey(c => c.AuthorId);

            builder.HasOne(c => c.Room)
                .WithMany(r => r.Messages)
                .HasForeignKey(c => c.RoomId);
        }
    }
}
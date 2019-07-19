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
            builder.Property(x => x.Room).IsRequired();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.SentTime).IsRequired();
            builder.Property(x => x.LastModified).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.MessageText).IsRequired();
        }
    }
}
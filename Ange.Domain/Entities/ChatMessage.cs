namespace Ange.Domain.Entities
{
    using System;
    using Enumerations;

    public class ChatMessage
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime LastModified { get; set; }
        public MessageType Type { get; set; }
        public string MessageText { get; set; }

        public User Author { get; set; }
        public Room Room { get; set; }
    }
}
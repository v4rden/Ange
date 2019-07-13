namespace Ange.Domain.Entities
{
    using System;
    using Enumerations;

    public class Message
    {
        public Guid Id { get; set; }
        public Guid Room { get; set; }
        public Guid Author { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime LastModified { get; set; }
        public MessageType Type { get; set; }
        public string MessageText { get; set; }
    }
}
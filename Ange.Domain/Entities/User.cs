namespace Ange.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            RecideRooms = new HashSet<UserRoom>();
            Messages = new HashSet<ChatMessage>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<UserRoom> RecideRooms { get; private set; }
        public ICollection<ChatMessage> Messages { get; private set; }
    }
}
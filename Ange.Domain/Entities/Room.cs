namespace Ange.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using Enumerations;

    public class Room
    {
        public Room()
        {
            Participants = new HashSet<Guid>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid RoomCreator { get; set; }
        public RoomType Type { get; set; }
        public ICollection<Guid> Participants { get; private set; }
    }
}
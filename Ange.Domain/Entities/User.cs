namespace Ange.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            RecideRooms = new HashSet<Guid>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Guid> RecideRooms { get; private set; }
    }
}
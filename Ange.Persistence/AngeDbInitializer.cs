namespace Ange.Persistence
{
    using System;
    using System.Linq;
    using Domain.Entities;
    using Domain.Enumerations;
    using Microsoft.EntityFrameworkCore;

    public class AngeDbInitializer
    {
        private static Guid User1 => new Guid("5FF58A35-6F97-409E-97F3-2BDEF56AC920");
        private static Guid User2 => new Guid("926DD24F-76C3-4F87-B19C-7438DCBEF02F");
        private static Guid Room1 => new Guid("10A196F9-8B78-4833-A838-0E234FA376DE");
        private static Guid Room2 => new Guid("23F7BAB7-F2A1-45A0-9712-ED21A1D93AAD");
        private static Guid Room3 => new Guid("AAA39DDA-B220-4112-892C-7A6DC865C908");

        public static void Initialize(AngeDbContext context)
        {
            var initializer = new AngeDbInitializer();
            initializer.SeedEverything(context);
        }

        private void SeedEverything(AngeDbContext context)
        {
            context.Database.Migrate();

            if (context.ChatMessages.Any())
            {
                return;
            }

            SeedUsers(context);
            SeedRooms(context);
            SeedMessages(context);
        }

        private void SeedUsers(AngeDbContext context)
        {
            var users = new[]
            {
                new User {Id = User1, Name = "User1", Country = "Paraguay"},
                new User {Id = User2, Name = "User2", Country = "Tuvalu"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private void SeedRooms(AngeDbContext context)
        {
            var rooms = new[]
            {
                new Room
                {
                    Id = Room1, Title = "PersonalRoom1",
                    RoomCreator = User1, Type = RoomType.Personal
                },
                new Room
                {
                    Id = Room2, Title = "PersonalRoom2",
                    RoomCreator = User2, Type = RoomType.Personal
                },
                new Room
                {
                    Id = Room3, Title = "PublicRoom",
                    RoomCreator = User1, Type = RoomType.Public
                },
            };

            context.Rooms.AddRange(rooms);
            context.SaveChanges();
        }

        private void SeedMessages(AngeDbContext context)
        {
            var messages = new[]
            {
                new ChatMessage
                {
                    Id = new Guid("00305EDD-7EEA-46BD-8DD6-AD0C2483F3E1"),
                    RoomId = Room1,
                    AuthorId = User1,
                    SentTime = DateTime.UtcNow,
                    Type = MessageType.Text,
                    MessageText = "A note to self."
                },
                new ChatMessage
                {
                    Id = new Guid("DC698673-79ED-49A5-9813-46AA1B10F8C3"),
                    RoomId = Room2,
                    AuthorId = User2,
                    SentTime = DateTime.UtcNow,
                    Type = MessageType.Text,
                    MessageText = "Something."
                },
                new ChatMessage
                {
                    Id = new Guid("3A56F844-16B1-481F-8C9A-ECBF10F0F0B5"),
                    RoomId = Room3,
                    AuthorId = User1,
                    SentTime = DateTime.UtcNow,
                    Type = MessageType.Text,
                    MessageText = "Message from user1 to user2."
                },
                new ChatMessage
                {
                    Id = new Guid("DB31F61C-4781-48AC-A98E-0C248475EDE1"),
                    RoomId = Room3,
                    AuthorId = User2,
                    SentTime = DateTime.UtcNow,
                    Type = MessageType.Text,
                    MessageText = "Message from user2 to user1."
                },
            };
        }
    }
}
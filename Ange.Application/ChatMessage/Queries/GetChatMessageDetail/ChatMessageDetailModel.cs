namespace Ange.Application.ChatMessage.Queries.GetChatMessageDetail
{
    using System;
    using System.Linq.Expressions;
    using Domain.Entities;
    using Domain.Enumerations;

    public class ChatMessageDetailModel
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime LastModified { get; set; }
        public MessageType Type { get; set; }
        public string MessageText { get; set; }

        public static Expression<Func<ChatMessage, ChatMessageDetailModel>> Projection
        {
            get
            {
                return chatMessage => new ChatMessageDetailModel
                {
                    Id = chatMessage.Id,
                    RoomId = chatMessage.RoomId,
                    AuthorId = chatMessage.AuthorId,
                    SentTime = chatMessage.SentTime,
                    LastModified = chatMessage.LastModified,
                    Type = chatMessage.Type,
                    MessageText = chatMessage.MessageText,
                };
            }
        }

        public static ChatMessageDetailModel Create(ChatMessage chatMessage)
        {
            return Projection.Compile().Invoke(chatMessage);
        }
    }
}
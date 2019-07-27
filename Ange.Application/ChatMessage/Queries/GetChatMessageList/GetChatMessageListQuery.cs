namespace Ange.Application.ChatMessage.Queries.GetChatMessageList
{
    using System;
    using MediatR;

    public class GetChatMessageListQuery : IRequest<ChatMessageListViewModel>
    {
        public string SubString { get; set; }
        public Guid RoomId { get; set; }
    }
}
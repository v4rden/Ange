namespace Ange.Application.ChatMessage.Queries.GetChatMessageDetail
{
    using System;
    using MediatR;

    public class GetChatMessageDetailQuery : IRequest<ChatMessageDetailModel>
    {
        public Guid Id { get; set; }
    }
}
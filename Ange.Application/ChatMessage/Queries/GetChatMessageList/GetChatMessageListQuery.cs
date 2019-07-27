namespace Ange.Application.ChatMessage.Queries.GetChatMessageList
{
    using MediatR;

    public class GetChatMessageListQuery : IRequest<ChatMessageListViewModel>
    {
        public string SubString { get; set; }
    }
}
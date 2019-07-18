namespace Ange.Application.ChatMessage.Queries.GetChatMessageList
{
    using System.Collections.Generic;

    public class ChatMessageListViewModel
    {
        public IList<ChatMessageLookupModel> ChatMessages { get; set; }
    }
}
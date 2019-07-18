namespace Ange.Application.ChatMessage.Queries.GetChatMessageDetail
{
    using FluentValidation;

    public class GetChatMessageDetailValidator : AbstractValidator<GetChatMessageDetailQuery>
    {
        public GetChatMessageDetailValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
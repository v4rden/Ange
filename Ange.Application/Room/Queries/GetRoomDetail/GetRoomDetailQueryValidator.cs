namespace Ange.Application.User.Queries.GetUserDetail
{
    using FluentValidation;
    using Room.Queries.GetRoomDetail;

    public class GetRoomDetailQueryValidator : AbstractValidator<GetRoomDetailQuery>
    {
        public GetRoomDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
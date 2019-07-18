namespace Ange.Application.Room.CreateRoom
{
    using FluentValidation;

    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).Length(100).NotEmpty();
            RuleFor(x => x.RoomCreator).NotEmpty();
            RuleFor(x => x.RoomType).NotEmpty();
        }
    }
}
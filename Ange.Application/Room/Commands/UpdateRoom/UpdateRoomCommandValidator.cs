namespace Ange.Application.Room.UpdateRoom
{
    using FluentValidation;

    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.Title).Length(100).NotEmpty();
        }
    }
}
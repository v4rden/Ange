namespace Ange.Application.User.Commands.UpdateUser
{
    using FluentValidation;

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Name).Length(75).NotEmpty();
            RuleFor(x => x.Country).Length(50);
        }
    }
}
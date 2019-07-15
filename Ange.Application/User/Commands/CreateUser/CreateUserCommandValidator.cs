namespace Ange.Application.User.Commands.CreateUser
{
    using FluentValidation;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).Length(75).NotEmpty();
            RuleFor(x => x.Country).Length(50);
        }
    }
}
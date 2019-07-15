namespace Ange.Application.User.Commands.DeleteUser
{
    using FluentValidation;

    public class UserDeleted : AbstractValidator<DeleteUserCommand>
    {
        public UserDeleted()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
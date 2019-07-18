namespace Ange.Application.User.Queries.GetUserDetail
{
    using FluentValidation;

    public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
    {
        public GetUserDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
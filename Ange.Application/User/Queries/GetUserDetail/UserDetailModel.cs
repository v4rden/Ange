namespace Ange.Application.User.Queries.GetUserDetail
{
    using System;
    using System.Linq.Expressions;
    using Domain.Entities;

    public class UserDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public static Expression<Func<User, UserDetailModel>> Projection
        {
            get
            {
                return customer => new UserDetailModel
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Country = customer.Country,
                };
            }
        }

        public static UserDetailModel Create(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}
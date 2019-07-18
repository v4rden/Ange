namespace Ange.Application.User.Queries.GetUserList
{
    using System;
    using AutoMapper;
    using Domain.Entities;
    using Interfaces.Mapping;

    public class UserLookupModel : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, UserLookupModel>()
                .ForMember(uDto => uDto.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(uDto => uDto.Name, opt => opt.MapFrom(u => u.Name));
        }
    }
}
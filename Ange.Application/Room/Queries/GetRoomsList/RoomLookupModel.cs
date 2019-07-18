namespace Ange.Application.Room.Queries.GetRoomsList
{
    using System;
    using AutoMapper;
    using Domain.Entities;
    using Interfaces.Mapping;

    public class RoomLookupModel : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Room, RoomLookupModel>()
                .ForMember(rDto => rDto.Id, opt => opt.MapFrom(r => r.Id))
                .ForMember(rDto => rDto.Title, opt => opt.MapFrom(r => r.Title));
        }
    }
}
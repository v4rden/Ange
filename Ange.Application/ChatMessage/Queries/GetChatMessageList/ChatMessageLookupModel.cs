namespace Ange.Application.ChatMessage.Queries.GetChatMessageList
{
    using System;
    using AutoMapper;
    using Domain.Enumerations;
    using Domain.Entities;
    using Interfaces.Mapping;

    public class ChatMessageLookupModel : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public Guid Room { get; set; }
        public Guid Author { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime LastModified { get; set; }
        public MessageType Type { get; set; }
        public string MessageText { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<ChatMessage, ChatMessageLookupModel>()
                .ForMember(mDto => mDto.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(mDto => mDto.Room, opt => opt.MapFrom(m => m.Room))
                .ForMember(mDto => mDto.Author, opt => opt.MapFrom(m => m.Author))
                .ForMember(mDto => mDto.SentTime, opt => opt.MapFrom(m => m.SentTime))
                .ForMember(mDto => mDto.LastModified, opt => opt.MapFrom(m => m.LastModified))
                .ForMember(mDto => mDto.Type, opt => opt.MapFrom(m => m.Type))
                .ForMember(mDto => mDto.MessageText, opt => opt.MapFrom(m => m.MessageText));
        }
    }
}
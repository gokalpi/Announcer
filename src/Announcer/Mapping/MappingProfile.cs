using Announcer.Dtos.Requests;
using Announcer.Dtos.Responses;
using Announcer.Models;
using AutoMapper;

namespace Announcer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDTO>()
                .ForMember(dest => dest.Template,
                    opt => opt.MapFrom(src => src.Template.Name));
            CreateMap<Group, GroupDTO>();
            CreateMap<GroupMember, GroupMemberDTO>()
                .ForMember(dest => dest.Group,
                    opt => opt.MapFrom(src => src.Group.Name))
                .ForMember(dest => dest.Client,
                    opt => opt.MapFrom(src => src.Client.Name));
            CreateMap<Notification, NotificationDTO>()
                .ForMember(dest => dest.Sender,
                    opt => opt.MapFrom(src => src.Sender.Name))
                .ForMember(dest => dest.Group,
                    opt => opt.MapFrom(src => src.Group.Name))
                .ForMember(dest => dest.Recipient,
                    opt => opt.MapFrom(src => src.Recipient.Name));
            CreateMap<Template, TemplateDTO>();

            CreateMap<SaveClientDTO, Client>();
            CreateMap<SaveGroupDTO, Group>();
            CreateMap<SaveGroupMemberDTO, GroupMember>();
            CreateMap<SaveNotificationDTO, Notification>();
            CreateMap<SaveTemplateDTO, Template>();
        }
    }
}
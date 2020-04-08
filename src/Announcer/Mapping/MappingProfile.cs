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
                .ForMember(dest => dest.GroupCount,
                    opt => opt.MapFrom(src => src.Groups.Count))
                .ForMember(dest => dest.NotificationsSentCount,
                    opt => opt.MapFrom(src => src.NotificationsSent.Count))
                .ForMember(dest => dest.NotificationsReceivedCount,
                    opt => opt.MapFrom(src => src.NotificationsReceived.Count))
                .ForMember(dest => dest.Template,
                    opt => opt.MapFrom(src => src.Template.Content));
            CreateMap<Group, GroupDTO>()
                .ForMember(dest => dest.ClientCount,
                    opt => opt.MapFrom(src => src.Clients.Count))
                .ForMember(dest => dest.NotificationsReceivedCount,
                    opt => opt.MapFrom(src => src.NotificationsReceived.Count));
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
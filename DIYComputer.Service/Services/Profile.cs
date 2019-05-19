using AutoMapper;
using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.SysEntity;
using DIYComputer.Service.IServices;

namespace DIYComputer.Service.Services
{
    public class MyProfile : Profile, IProfile
    {
        public MyProfile()
        {
            //CreateMap<Topic, TopicListModel>()//topic 源 topiclistmodel 目标值
            //    .ForMember(o=>o.UserID,opt=>opt.MapFrom(t=>t.UserID))
            //    .ForMember(o=>o.Account,opt=>opt.MapFrom(t=>t.User.Account))
            //    ;
            //CreateMap<TopicListModel, Topic>()
            //    .ForMember(o=>o.User,opt=>opt.Ignore())
            //    ;

            CreateMap<UserRegisterModel, User>()
                .ForMember(o => o.Topics, opt => opt.Ignore())
                .ForMember(o => o.CreateTime, opt => opt.Ignore())
                .ForMember(o => o.EditTime, opt => opt.Ignore())
                .ForMember(o => o.Topics, opt => opt.Ignore())
                .ForMember(o => o.LastTime, opt => opt.Ignore());

            CreateMap<UserLoginModel, User>()
                .ForMember(o => o.Topics, opt => opt.Ignore())
                .ForMember(o => o.Topics, opt => opt.Ignore())
                .ForMember(o => o.CreateTime, opt => opt.Ignore())
                .ForMember(o => o.EditTime, opt => opt.Ignore())
                .ForMember(o => o.LastTime, opt => opt.Ignore());

            CreateMap<UserDisplayModel, User>()
                .ForMember(o => o.Id, opt => opt.Ignore())
                .ForMember(o => o.CreateTime, opt => opt.Ignore())
                .ForMember(o => o.EditTime, opt => opt.Ignore())
                .ForMember(o => o.LastTime, opt => opt.Ignore())
                .ForMember(o => o.Integral, opt => opt.Ignore());
            CreateMap<UserEditModel, User>()
                .ForMember(o => o.Id, opt => opt.Ignore())
                .ForMember(o => o.Account, opt => opt.Ignore())
                .ForMember(o => o.Integral, opt => opt.Ignore())
                .ForMember(o => o.CreateTime, opt => opt.Ignore())
                .ForMember(o => o.EditTime, opt => opt.Ignore());
            CreateMap<User, UserEditModel>();


            CreateMap<Topic, TopicListModel>()//topic 源 topiclistmodel 目标值
               .ForMember(o => o.UserID, opt => opt.MapFrom(t => t.UserId))
               .ForMember(o => o.Account, opt => opt.MapFrom(t => t.User.Account))
               ;
            CreateMap<TopicListModel, Topic>()
                .ForMember(o => o.User, opt => opt.Ignore())
                ;
            CreateMap<ComputerDto, Computer>();
            CreateMap<Computer, ComputerDto>()
                .ForMember(o => o.UserDisplay, opt => opt.Ignore());
               

        }

    }
}

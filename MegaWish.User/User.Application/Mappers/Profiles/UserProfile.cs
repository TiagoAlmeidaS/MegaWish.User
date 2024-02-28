using AutoMapper;
using User.Application.UseCases.User.Command.AddUser;
using User.Domain.Entities;

namespace User.Application.Mappers.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<AddUserCommand, UserEntity>().ReverseMap()
            .ForMember(x => x.CustomerDocument, opt => opt.MapFrom(x => x.CustomerDocument))
            .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber))
            .ForMember(x => x.YearsOld , opt => opt.MapFrom(x => x.YearOld))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        
    }
}
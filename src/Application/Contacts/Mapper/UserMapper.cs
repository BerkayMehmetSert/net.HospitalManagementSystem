using Application.Contacts.Requests.Users;
using Application.Contacts.Responses.Users;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<RegisterUserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
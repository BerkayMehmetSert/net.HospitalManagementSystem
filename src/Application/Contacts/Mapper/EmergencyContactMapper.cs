using Application.Contacts.Requests.EmergencyContacts;
using Application.Contacts.Responses.EmergencyContacts;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class EmergencyContactMapper : Profile
{
    public EmergencyContactMapper()
    {
        CreateMap<CreateEmergencyContactRequest, EmergencyContact>();
        CreateMap<UpdateEmergencyRequest, EmergencyContact>();
        CreateMap<UpdateEmergencyContactRequest, EmergencyContact>();
        CreateMap<UpdateEmergencyContactRelationshipRequest, EmergencyContact>();
        CreateMap<EmergencyContact, EmergencyContactResponse>();
    }
}
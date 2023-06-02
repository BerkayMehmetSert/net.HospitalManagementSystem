using Application.Contacts.Requests.PatientFollowUps;
using Application.Contacts.Responses.PatientFollowUps;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class PatientFollowUpMapper : Profile
{
    public PatientFollowUpMapper()
    {
        CreateMap<CreatePatientFollowUpRequest, PatientFollowUp>();
        CreateMap<PatientFollowUp, PatientFollowUpResponse>();
    }
}
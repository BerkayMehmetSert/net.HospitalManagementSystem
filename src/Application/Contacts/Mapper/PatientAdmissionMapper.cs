using Application.Contacts.Requests.PatientAdmissions;
using Application.Contacts.Responses.PatientAdmissions;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class PatientAdmissionMapper : Profile
{
    public PatientAdmissionMapper()
    {
        CreateMap<CreatePatientAdmissionRequest, PatientAdmission>();
        CreateMap<UpdatePatientAdmissionNumbersRequest, PatientAdmission>();
        CreateMap<PatientAdmission, PatientAdmissionResponse>();
    }
}
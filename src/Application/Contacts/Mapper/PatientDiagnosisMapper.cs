using Application.Contacts.Requests.PatientDiagnoses;
using Application.Contacts.Responses.PatientDiagnoses;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class PatientDiagnosisMapper : Profile
{
    public PatientDiagnosisMapper()
    {
        CreateMap<CreatePatientDiagnosisRequest, PatientDiagnosis>();
        CreateMap<PatientDiagnosis, PatientDiagnosisResponse>();
    }
}
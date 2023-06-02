using Application.Contacts.Requests.PatientHistories;
using Application.Contacts.Responses.PatientHistories;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class PatientHistoryMapper : Profile
{
    public PatientHistoryMapper()
    {
        CreateMap<CreatePatientHistoryRequest, PatientHistory>();
        CreateMap<PatientHistory, PatientHistoryResponse>();
    }
}
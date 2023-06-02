using Application.Contacts.Requests.HospitalDiagnosisLists;
using Application.Contacts.Responses.HospitalDiagnosisLists;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class HospitalDiagnosisListMapper : Profile
{
    public HospitalDiagnosisListMapper()
    {
        CreateMap<CreateHospitalDiagnosisListRequest, HospitalDiagnosisList>();
        CreateMap<UpdateHospitalDiagnosisListContactRequest, HospitalDiagnosisList>();
        CreateMap<HospitalDiagnosisList, HospitalDiagnosisListResponse>();
    }
}
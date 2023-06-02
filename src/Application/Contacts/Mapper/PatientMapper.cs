using Application.Contacts.Requests.HealthInsurances;
using Application.Contacts.Requests.Patients;
using Application.Contacts.Responses.HealthInsurances;
using Application.Contacts.Responses.Patients;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class PatientMapper : Profile
{
    public PatientMapper()
    {
        CreateMap<CreatePatientRequest, Patient>();
        CreateMap<UpdatePatientContactRequest, Patient>();
        CreateMap<UpdatePatientEmergencyContactRequest, Patient>();
        CreateMap<UpdatePatientNameRequest, Patient>();
        CreateMap<CreateHealthInsuranceRequest, HealthInsurance>();
        CreateMap<HealthInsurance, HealthInsuranceResponse>();
        CreateMap<PatientHealthInsurance, HealthInsurance>();
        CreateMap<Patient, PatientResponse>()
            .ForMember(dest => dest.HealthInsurances,
                opt => opt.MapFrom(src =>
                    src.PatientHealthInsurances != null
                        ? src.PatientHealthInsurances.Select(ur => ur.HealthInsurance)
                        : null));
    }
}
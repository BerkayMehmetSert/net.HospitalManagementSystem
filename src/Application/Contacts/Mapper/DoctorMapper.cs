using Application.Contacts.Requests.Doctors;
using Application.Contacts.Responses.Doctors;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class DoctorMapper : Profile
{
    public DoctorMapper()
    {
        CreateMap<CreateDoctorRequest, Doctor>();
        CreateMap<UpdateDoctorRequest, Doctor>();
        CreateMap<UpdateDoctorContactRequest, Doctor>();
        CreateMap<UpdateDoctorDepartmentRequest, Doctor>();
        CreateMap<Doctor, DoctorResponse>();
    }
}
using Application.Contacts.Requests.Departments;
using Application.Contacts.Responses.Departments;
using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Mapper;

public class DepartmentMapper : Profile
{
    public DepartmentMapper()
    {
        CreateMap<CreateDepartmentRequest, Department>();
        CreateMap<UpdateDepartmentContactRequest, Department>();
        CreateMap<Department, DepartmentResponse>();
    }
}
using Application.Contacts.Requests.Departments;
using Application.Contacts.Responses.Departments;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IDepartmentService
{
    void CreateDepartment(CreateDepartmentRequest request);
    void UpdateDepartmentContact(Guid id, UpdateDepartmentContactRequest request);
    void DeleteDepartment(Guid id);
    DepartmentResponse GetDepartmentById(Guid id);
    DepartmentResponse GetDepartmentByName(string name);
    List<DepartmentResponse> GetAllDepartments();
    Department GetDepartmentEntity(Guid id);
}
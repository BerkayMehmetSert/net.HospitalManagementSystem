using Application.Contacts.Requests.Doctors;
using Application.Contacts.Responses.Doctors;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IDoctorService
{
    void CreateDoctor(CreateDoctorRequest request);
    void UpdateDoctor(Guid id, UpdateDoctorRequest request);
    void UpdateDoctorContact(Guid id, UpdateDoctorContactRequest request);
    void UpdateDoctorDepartment(Guid id, UpdateDoctorDepartmentRequest request);
    void DeleteDoctor(Guid id);
    DoctorResponse GetDoctorById(Guid id);
    DoctorResponse GetDoctorByFirstNameAndLastName(string firstName, string lastName);
    List<DoctorResponse> GetAllDoctors();
    Doctor GetDoctorEntity(Guid id);
}
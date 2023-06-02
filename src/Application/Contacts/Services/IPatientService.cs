using Application.Contacts.Requests.Patients;
using Application.Contacts.Responses.Patients;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IPatientService
{
    void CreatePatient(CreatePatientRequest request);
    void UpdatePatientContact(Guid id, UpdatePatientContactRequest request);
    void UpdatePatientEmergencyContact(Guid id, UpdatePatientEmergencyContactRequest request);
    void UpdatePatientName(Guid id, UpdatePatientNameRequest request);
    void DeletePatient(Guid id);
    PatientResponse GetPatientById(Guid id);
    PatientResponse GetPatientByFirstNameAndLastName(string firstName, string lastName);
    List<PatientResponse> GetAllPatients();
    Patient GetPatientEntity(Guid id);
}
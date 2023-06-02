using Application.Contacts.Requests.PatientAdmissions;
using Application.Contacts.Responses.PatientAdmissions;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IPatientAdmissionService
{
    void CreatePatientAdmission(CreatePatientAdmissionRequest request);
    void UpdatePatientAdmissionNumber(Guid id, UpdatePatientAdmissionNumbersRequest request);
    void DeletePatientAdmission(Guid id);
    PatientAdmissionResponse GetPatientAdmissionById(Guid id);
    List<PatientAdmissionResponse> GetAllPatientAdmissions();
    PatientAdmission GetPatientAdmissionEntity(Guid id);
}
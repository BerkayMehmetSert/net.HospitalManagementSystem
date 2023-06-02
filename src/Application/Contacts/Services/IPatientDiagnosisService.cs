using Application.Contacts.Requests.PatientDiagnoses;
using Application.Contacts.Responses.PatientDiagnoses;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IPatientDiagnosisService
{
    void CreatePatientDiagnosis(CreatePatientDiagnosisRequest request);
    PatientDiagnosisResponse GetPatientDiagnosisById(Guid id);
    List<PatientDiagnosisResponse> GetAllPatientDiagnoses();
    PatientDiagnosis GetPatientDiagnosisEntity(Guid id);
}
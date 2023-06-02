using Application.Contacts.Requests.PatientFollowUps;
using Application.Contacts.Responses.PatientFollowUps;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IPatientFollowUpService
{
    void CreatePatientFollowUp(CreatePatientFollowUpRequest request);
    PatientFollowUpResponse GetPatientFollowUpById(Guid id);
    List<PatientFollowUpResponse> GetAllPatientFollowUps();
    PatientFollowUp GetPatientFollowUpEntity(Guid id);
}
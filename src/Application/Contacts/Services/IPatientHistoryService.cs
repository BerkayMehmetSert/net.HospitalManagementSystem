using Application.Contacts.Requests.PatientHistories;
using Application.Contacts.Responses.PatientHistories;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IPatientHistoryService
{
    void CreatePatientHistory(CreatePatientHistoryRequest request);
    PatientHistoryResponse GetPatientHistoryById(Guid id);
    List<PatientHistoryResponse> GetAllPatientHistories();
    List<PatientHistoryResponse> GetAllPatientHistoriesOrderByDateOfVisit();
    PatientHistory GetPatientHistoryEntity(Guid id);
}
using Application.Contacts.Requests.HospitalDiagnosisLists;
using Application.Contacts.Responses.HospitalDiagnosisLists;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IHospitalDiagnosisListService
{
    void CreateHospitalDiagnosisList(CreateHospitalDiagnosisListRequest request);
    void UpdateHospitalDiagnosisListContact(Guid id, UpdateHospitalDiagnosisListContactRequest request);
    void DeleteHospitalDiagnosisList(Guid id);
    HospitalDiagnosisListResponse GetHospitalDiagnosisListById(Guid id);
    List<HospitalDiagnosisListResponse> GetAllHospitalDiagnosisLists();
    HospitalDiagnosisList GetHospitalDiagnosisListEntity(Guid id);
}
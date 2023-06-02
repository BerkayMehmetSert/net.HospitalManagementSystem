using Application.Contacts.Repositories;
using Application.Contacts.Requests.PatientAdmissions;
using Application.Contacts.Responses.PatientAdmissions;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Infrastructure.Utilities.Date;
using static Application.Contacts.Messages.PatientAdmissions.BusinessMessages;

namespace Application.Services;

public class PatientAdmissionService : IPatientAdmissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPatientHistoryService _patientHistoryService;

    public PatientAdmissionService(IUnitOfWork unitOfWork, IMapper mapper,
        IPatientHistoryService patientHistoryService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _patientHistoryService = patientHistoryService;
    }

    public void CreatePatientAdmission(CreatePatientAdmissionRequest request)
    {
        var patientHistory = _patientHistoryService.GetPatientHistoryEntity(request.PatientHistoryId);

        var patientAdmission = _mapper.Map<PatientAdmission>(request);
        patientAdmission.PatientHistory = patientHistory;
        patientAdmission.DateOfAdmission = CalculateDate.GetCurrentDateTime();
        patientAdmission.DateOfDischarge = CalculateDate.GetCurrentDateTime();

        _unitOfWork.PatientAdmissionRepository.Create(patientAdmission);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePatientAdmissionNumber(Guid id, UpdatePatientAdmissionNumbersRequest request)
    {
        var patientAdmission = GetPatientAdmissionEntity(id);

        var updatedPatientAdmission = _mapper.Map(request, patientAdmission);

        _unitOfWork.PatientAdmissionRepository.Update(updatedPatientAdmission);
        _unitOfWork.SaveChanges();
    }

    public void DeletePatientAdmission(Guid id)
    {
        var patientAdmission = GetPatientAdmissionEntity(id);

        _unitOfWork.PatientAdmissionRepository.Delete(patientAdmission);
        _unitOfWork.SaveChanges();
    }

    public PatientAdmissionResponse GetPatientAdmissionById(Guid id)
    {
        var patientAdmission = GetPatientAdmissionEntity(id);

        return _mapper.Map<PatientAdmissionResponse>(patientAdmission);
    }

    public List<PatientAdmissionResponse> GetAllPatientAdmissions()
    {
        var patientAdmissions = _unitOfWork.PatientAdmissionRepository.GetAll();

        return patientAdmissions.Any()
            ? _mapper.Map<List<PatientAdmissionResponse>>(patientAdmissions)
            : throw new NotFoundException(PatientAdmissionListIsEmpty);
    }

    public PatientAdmission GetPatientAdmissionEntity(Guid id)
    {
        var patientAdmission = _unitOfWork.PatientAdmissionRepository.Get(predicate: x => x.Id.Equals(id));

        return patientAdmission ?? throw new NotFoundException(PatientAdmissionNotFoundById);
    }
}
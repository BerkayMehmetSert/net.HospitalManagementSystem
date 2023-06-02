using Application.Contacts.Repositories;
using Application.Contacts.Requests.PatientFollowUps;
using Application.Contacts.Responses.PatientFollowUps;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Infrastructure.Utilities.Date;
using static Application.Contacts.Messages.PatientFollowUps.BusinessMessages;

namespace Application.Services;

public class PatientFollowUpService : IPatientFollowUpService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPatientHistoryService _patientHistoryService;

    public PatientFollowUpService(IUnitOfWork unitOfWork, IMapper mapper,
        IPatientHistoryService patientHistoryService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _patientHistoryService = patientHistoryService;
    }

    public void CreatePatientFollowUp(CreatePatientFollowUpRequest request)
    {
        var patientHistory = _patientHistoryService.GetPatientHistoryEntity(request.PatientHistoryId);

        var patientFollowUp = _mapper.Map<PatientFollowUp>(request);
        patientFollowUp.PatientHistory = patientHistory;
        patientFollowUp.DateOfFollowUp = CalculateDate.GetCurrentDateTime();

        _unitOfWork.PatientFollowUpRepository.Create(patientFollowUp);
        _unitOfWork.SaveChanges();
    }

    public PatientFollowUpResponse GetPatientFollowUpById(Guid id)
    {
        var patientFollowUp = GetPatientFollowUpEntity(id);
        
        return _mapper.Map<PatientFollowUpResponse>(patientFollowUp);
    }

    public List<PatientFollowUpResponse> GetAllPatientFollowUps()
    {
        var patientFollowUps = _unitOfWork.PatientFollowUpRepository.GetAll();

        return patientFollowUps.Any()
            ? _mapper.Map<List<PatientFollowUpResponse>>(patientFollowUps)
            : throw new NotFoundException(PatientFollowUpListIsEmpty);
    }

    public PatientFollowUp GetPatientFollowUpEntity(Guid id)
    {
        var patientFollowUp = _unitOfWork.PatientFollowUpRepository.Get(x => x.Id.Equals(id));

        return patientFollowUp ?? throw new NotFoundException(PatientFollowUpNotFoundById);
    }
}
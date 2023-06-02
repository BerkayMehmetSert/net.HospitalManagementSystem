using Application.Contacts.Repositories;
using Application.Contacts.Requests.PatientHistories;
using Application.Contacts.Responses.PatientHistories;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Infrastructure.Utilities.Date;
using Microsoft.EntityFrameworkCore;
using static Application.Contacts.Messages.PatientHistories.BusinessMessages;

namespace Application.Services;

public class PatientHistoryService : IPatientHistoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;

    public PatientHistoryService(IUnitOfWork unitOfWork, IMapper mapper, IDoctorService doctorService,
        IPatientService patientService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _doctorService = doctorService;
        _patientService = patientService;
    }

    public void CreatePatientHistory(CreatePatientHistoryRequest request)
    {
        var doctor = _doctorService.GetDoctorEntity(request.DoctorId);
        var patient = _patientService.GetPatientEntity(request.PatientId);

        var patientHistory = _mapper.Map<PatientHistory>(request);
        patientHistory.Doctor = doctor;
        patientHistory.Patient = patient;
        patientHistory.DateOfVisit = CalculateDate.GetCurrentDateTime();

        _unitOfWork.PatientHistoryRepository.Create(patientHistory);
        _unitOfWork.SaveChanges();
    }

    public PatientHistoryResponse GetPatientHistoryById(Guid id)
    {
        var patientHistory = GetPatientHistoryEntity(id);

        return _mapper.Map<PatientHistoryResponse>(patientHistory);
    }

    public List<PatientHistoryResponse> GetAllPatientHistories()
    {
        var patientHistories = _unitOfWork.PatientHistoryRepository.GetAll(
            include: source => source
                .Include(x => x.PatientFollowUps)
                .Include(x => x.PatientDiagnoses)
                .Include(x => x.PatientAdmissions)
        );

        return patientHistories.Any()
            ? _mapper.Map<List<PatientHistoryResponse>>(patientHistories)
            : throw new NotFoundException(PatientHistoryListIsEmpty);
    }

    public List<PatientHistoryResponse> GetAllPatientHistoriesOrderByDateOfVisit()
    {
        var patientHistories = _unitOfWork.PatientHistoryRepository.GetAll(
            orderBy: source => source.OrderByDescending(x => x.DateOfVisit),
            include: source => source
                .Include(x => x.PatientFollowUps)
                .Include(x => x.PatientDiagnoses)
                .Include(x => x.PatientAdmissions)
        );
        
        return patientHistories.Any()
            ? _mapper.Map<List<PatientHistoryResponse>>(patientHistories)
            : throw new NotFoundException(PatientHistoryListIsEmpty);
    }

    public PatientHistory GetPatientHistoryEntity(Guid id)
    {
        var patientHistory = _unitOfWork.PatientHistoryRepository.Get(
            predicate: x => x.Id.Equals(id),
            include: source => source
                .Include(x => x.PatientFollowUps)
                .Include(x => x.PatientDiagnoses)
                .Include(x => x.PatientAdmissions)
        );

        return patientHistory ?? throw new NotFoundException(PatientHistoryNotFoundById);
    }
}
using Application.Contacts.Repositories;
using Application.Contacts.Requests.PatientDiagnoses;
using Application.Contacts.Responses.PatientDiagnoses;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Infrastructure.Utilities.Date;
using static Application.Contacts.Messages.PatientDiagnosises.BusinessMessages;

namespace Application.Services;

public class PatientDiagnosisService : IPatientDiagnosisService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPatientHistoryService _patientHistoryService;
    private readonly IDoctorService _doctorService;
    private readonly IHospitalDiagnosisListService _hospitalDiagnosisListService;

    public PatientDiagnosisService(IUnitOfWork unitOfWork, IMapper mapper, IPatientHistoryService patientHistoryService,
        IDoctorService doctorService, IHospitalDiagnosisListService hospitalDiagnosisListService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _patientHistoryService = patientHistoryService;
        _doctorService = doctorService;
        _hospitalDiagnosisListService = hospitalDiagnosisListService;
    }

    public void CreatePatientDiagnosis(CreatePatientDiagnosisRequest request)
    {
        var patientHistory = _patientHistoryService.GetPatientHistoryEntity(request.PatientHistoryId);
        var doctor = _doctorService.GetDoctorEntity(request.DoctorId);
        var hospitalDiagnosisList =
            _hospitalDiagnosisListService.GetHospitalDiagnosisListEntity(request.HospitalDiagnosisListId);
        
        var patientDiagnosis = _mapper.Map<PatientDiagnosis>(request);
        patientDiagnosis.PatientHistory = patientHistory;
        patientDiagnosis.Doctor = doctor;
        patientDiagnosis.HospitalDiagnosisList = hospitalDiagnosisList;
        patientDiagnosis.DateOfDiagnosis = CalculateDate.GetCurrentDateTime();
        
        _unitOfWork.PatientDiagnosisRepository.Create(patientDiagnosis);
        _unitOfWork.SaveChanges();
    }

    public PatientDiagnosisResponse GetPatientDiagnosisById(Guid id)
    {
        var patientDiagnosis = GetPatientDiagnosisEntity(id);
        
        return _mapper.Map<PatientDiagnosisResponse>(patientDiagnosis);
    }

    public List<PatientDiagnosisResponse> GetAllPatientDiagnoses()
    {
        var patientDiagnoses = _unitOfWork.PatientDiagnosisRepository.GetAll();

        return patientDiagnoses.Any()
            ? _mapper.Map<List<PatientDiagnosisResponse>>(patientDiagnoses)
            : throw new NotFoundException(PatientDiagnosisListIsEmpty);
    }

    public PatientDiagnosis GetPatientDiagnosisEntity(Guid id)
    {
        var patientDiagnosis = _unitOfWork.PatientDiagnosisRepository.Get(x => x.Id.Equals(id));

        return patientDiagnosis ?? throw new NotFoundException(PatientDiagnosisNotFoundById);
    }
}
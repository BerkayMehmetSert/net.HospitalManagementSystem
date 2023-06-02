using Application.Contacts.Repositories;
using Application.Contacts.Requests.Patients;
using Application.Contacts.Responses.Patients;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Microsoft.EntityFrameworkCore;
using static Application.Contacts.Messages.Patients.BusinessMessages;

namespace Application.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmergencyContactService _emergencyContactService;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper, IEmergencyContactService emergencyContactService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emergencyContactService = emergencyContactService;
    }

    public void CreatePatient(CreatePatientRequest request)
    {
        var companyNames = request.HealthInsurances.Select(x => x.CompanyName).ToArray();

        CheckIfPatientExistsByEmail(request.Email);
        CheckIfPatientHealthInsuranceExistByCompanyName(companyNames);

        var patient = _mapper.Map<Patient>(request);

        if (request.HealthInsurances.Any())
        {
            foreach (var healthInsuranceRequest in request.HealthInsurances)
            {
                var healthInsurance = _mapper.Map<HealthInsurance>(healthInsuranceRequest);
                var patientHealthInsurance = new PatientHealthInsurance
                {
                    Patient = patient,
                    HealthInsurance = healthInsurance
                };
                patient.PatientHealthInsurances.Add(patientHealthInsurance);
            }
        }

        _unitOfWork.PatientRepository.Create(patient);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePatientContact(Guid id, UpdatePatientContactRequest request)
    {
        var patient = GetPatientEntity(id);

        if (!string.Equals(patient.Email, request.Email, StringComparison.OrdinalIgnoreCase))
        {
            CheckIfPatientExistsByEmail(request.Email);
        }

        var updatedPatient = _mapper.Map(request, patient);

        _unitOfWork.PatientRepository.Update(updatedPatient);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePatientEmergencyContact(Guid id, UpdatePatientEmergencyContactRequest request)
    {
        var patient = GetPatientEntity(id);
        var emergencyContact = _emergencyContactService.GetEmergencyContactEntity(request.EmergencyContactId);

        patient.EmergencyContact = emergencyContact;

        _unitOfWork.PatientRepository.Update(patient);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePatientName(Guid id, UpdatePatientNameRequest request)
    {
        var patient = GetPatientEntity(id);

        var updatedPatient = _mapper.Map(request, patient);

        _unitOfWork.PatientRepository.Update(updatedPatient);
        _unitOfWork.SaveChanges();
    }

    public void DeletePatient(Guid id)
    {
        var patient = GetPatientEntity(id);

        _unitOfWork.PatientRepository.Delete(patient);
        _unitOfWork.SaveChanges();
    }

    public PatientResponse GetPatientById(Guid id)
    {
        var patient = GetPatientEntity(id);

        return _mapper.Map<PatientResponse>(patient);
    }

    public PatientResponse GetPatientByFirstNameAndLastName(string firstName, string lastName)
    {
        var patient = _unitOfWork.PatientRepository.Get(
            predicate: x => x.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                            x.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase),
            include: source => source
                .Include(x => x.PatientHealthInsurances)
                .Include(x => x.PatientHistories)
        );

        return patient is not null
            ? _mapper.Map<PatientResponse>(patient)
            : throw new NotFoundException(PatientNotFoundByFirstNameAndLastName);
    }

    public List<PatientResponse> GetAllPatients()
    {
        var patients = _unitOfWork.PatientRepository.GetAll(
            include: source => source
                .Include(x => x.PatientHealthInsurances)
                .ThenInclude(x => x.HealthInsurance)
                .Include(x => x.PatientHistories)
        );

        return patients.Any()
            ? _mapper.Map<List<PatientResponse>>(patients)
            : throw new NotFoundException(PatientListIsEmpty);
    }

    public Patient GetPatientEntity(Guid id)
    {
        var patient = _unitOfWork.PatientRepository.Get(
            predicate: x => x.Id.Equals(id),
            include: source => source
                .Include(x => x.PatientHealthInsurances)
                .ThenInclude(x => x.HealthInsurance)
                .Include(x => x.PatientHistories)
        );

        return patient ?? throw new BusinessException(PatientNotFoundById);
    }

    private void CheckIfPatientExistsByEmail(string email)
    {
        var patient = _unitOfWork.PatientRepository.Get(x => x.Email.Equals(email));

        if (patient is not null) throw new BusinessException(PatientAlreadyExistsByEmail);
    }

    private void CheckIfPatientHealthInsuranceExistByCompanyName(string[] companyNames)
    {
        if (!companyNames.Select(name => _unitOfWork.HealthInsuranceRepository.Get(x =>
                x.CompanyName.Equals(name))).Any())
        {
            throw new BusinessException(HealthInsuranceAlreadyExistsByCompanyName);
        }
    }
}
using Application.Contacts.Repositories;
using Application.Contacts.Requests.Doctors;
using Application.Contacts.Responses.Doctors;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Microsoft.EntityFrameworkCore;
using static Application.Contacts.Messages.Doctors.BusinessMessages;

namespace Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDepartmentService _departmentService;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, IDepartmentService departmentService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _departmentService = departmentService;
    }

    public void CreateDoctor(CreateDoctorRequest request)
    {
        CheckIfDoctorExistsByEmail(request.Email);

        var doctor = _mapper.Map<Doctor>(request);

        _unitOfWork.DoctorRepository.Create(doctor);
        _unitOfWork.SaveChanges();
    }

    public void UpdateDoctor(Guid id, UpdateDoctorRequest request)
    {
        var doctor = GetDoctorEntity(id);

        var updatedDoctor = _mapper.Map(request, doctor);

        _unitOfWork.DoctorRepository.Update(updatedDoctor);
        _unitOfWork.SaveChanges();
    }

    public void UpdateDoctorContact(Guid id, UpdateDoctorContactRequest request)
    {
        var doctor = GetDoctorEntity(id);

        if (!string.Equals(doctor.Email, request.Email, StringComparison.OrdinalIgnoreCase))
        {
            CheckIfDoctorExistsByEmail(request.Email);
        }

        var updatedDoctor = _mapper.Map(request, doctor);

        _unitOfWork.DoctorRepository.Update(updatedDoctor);
        _unitOfWork.SaveChanges();
    }

    public void UpdateDoctorDepartment(Guid id, UpdateDoctorDepartmentRequest request)
    {
        var doctor = GetDoctorEntity(id);
        var department = _departmentService.GetDepartmentEntity(request.DepartmentId);

        doctor.Department = department;

        _unitOfWork.DoctorRepository.Update(doctor);
        _unitOfWork.SaveChanges();
    }

    public void DeleteDoctor(Guid id)
    {
        var doctor = GetDoctorEntity(id);

        _unitOfWork.DoctorRepository.Delete(doctor);
        _unitOfWork.SaveChanges();
    }

    public DoctorResponse GetDoctorById(Guid id)
    {
        var doctor = GetDoctorEntity(id);

        return _mapper.Map<DoctorResponse>(doctor);
    }

    public DoctorResponse GetDoctorByFirstNameAndLastName(string firstName, string lastName)
    {
        var doctor = _unitOfWork.DoctorRepository.Get(
            predicate: x =>
                x.FirstName.Equals(firstName, StringComparison.Ordinal) &&
                x.LastName.Equals(lastName, StringComparison.Ordinal),
            include: source => source
                .Include(x => x.PatientDiagnoses)
                .Include(x => x.PatientHistories)
        );

        return doctor is not null
            ? _mapper.Map<DoctorResponse>(doctor)
            : throw new NotFoundException(DoctorNotFoundByFirstNameAndLastName);
    }

    public List<DoctorResponse> GetAllDoctors()
    {
        var doctors = _unitOfWork.DoctorRepository.GetAll(
            include: source => source
                .Include(x => x.PatientDiagnoses)
                .Include(x => x.PatientHistories)
        );

        return doctors.Any()
            ? _mapper.Map<List<DoctorResponse>>(doctors)
            : throw new NotFoundException(DoctorListIsEmpty);
    }

    public Doctor GetDoctorEntity(Guid id)
    {
        var doctor = _unitOfWork.DoctorRepository.Get(
            predicate: x => x.Id.Equals(id),
            include: source => source
                .Include(x => x.PatientDiagnoses)
                .Include(x => x.PatientHistories)
        );

        return doctor ?? throw new NotFoundException(DoctorNotFoundById);
    }

    private void CheckIfDoctorExistsByEmail(string email)
    {
        var doctor = _unitOfWork.DoctorRepository.Get(
            predicate: x => x.Email.Equals(email),
            include: source => source
                .Include(x => x.PatientDiagnoses)
                .Include(x => x.PatientHistories)
        );

        if (doctor is not null) throw new BusinessException(DoctorAlreadyExistsByEmail);
    }
}
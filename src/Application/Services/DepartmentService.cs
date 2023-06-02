using Application.Contacts.Repositories;
using Application.Contacts.Requests.Departments;
using Application.Contacts.Responses.Departments;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Microsoft.EntityFrameworkCore;
using static Application.Contacts.Messages.Departments.BusinessMessages;

namespace Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void CreateDepartment(CreateDepartmentRequest request)
    {
        CheckIfDepartmentExistsByName(request.Name);

        var department = _mapper.Map<Department>(request);

        _unitOfWork.DepartmentRepository.Create(department);
        _unitOfWork.SaveChanges();
    }

    public void UpdateDepartmentContact(Guid id, UpdateDepartmentContactRequest request)
    {
        var department = GetDepartmentEntity(id);

        var updatedDepartment = _mapper.Map(request, department);

        _unitOfWork.DepartmentRepository.Update(updatedDepartment);
        _unitOfWork.SaveChanges();
    }

    public void DeleteDepartment(Guid id)
    {
        var department = GetDepartmentEntity(id);

        _unitOfWork.DepartmentRepository.Delete(department);
        _unitOfWork.SaveChanges();
    }

    public DepartmentResponse GetDepartmentById(Guid id)
    {
        var department = GetDepartmentEntity(id);

        return _mapper.Map<DepartmentResponse>(department);
    }

    public DepartmentResponse GetDepartmentByName(string name)
    {
        var department = _unitOfWork.DepartmentRepository.Get(
            predicate: x => x.Name.Equals(name),
            include: source => source
                .Include(x => x.HospitalDiagnosisLists)
                .Include(x => x.Doctors)
        );

        return department is not null
            ? _mapper.Map<DepartmentResponse>(department)
            : throw new NotFoundException(DepartmentNotFoundByName);
    }

    public List<DepartmentResponse> GetAllDepartments()
    {
        var departments = _unitOfWork.DepartmentRepository.GetAll(
            include: source => source
                .Include(x => x.HospitalDiagnosisLists)
                .Include(x => x.Doctors)
        );

        return departments.Any()
            ? _mapper.Map<List<DepartmentResponse>>(departments)
            : throw new NotFoundException(DepartmentListIsEmpty);
    }

    public Department GetDepartmentEntity(Guid id)
    {
        var department = _unitOfWork.DepartmentRepository.Get(
            predicate: x => x.Id.Equals(id),
            include: source => source
                .Include(x => x.HospitalDiagnosisLists)
                .Include(x => x.Doctors)
        );

        return department ?? throw new NotFoundException(DepartmentNotFoundById);
    }

    private void CheckIfDepartmentExistsByName(string name)
    {
        var department = _unitOfWork.DepartmentRepository.Get(
            predicate: x => x.Name.Equals(name),
            include: source => source
                .Include(x => x.HospitalDiagnosisLists)
                .Include(x => x.Doctors)
        );

        if (department is not null) throw new BusinessException(DepartmentAlreadyExistsByName);
    }
}
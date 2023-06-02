using Application.Contacts.Repositories;
using Application.Contacts.Requests.HospitalDiagnosisLists;
using Application.Contacts.Responses.HospitalDiagnosisLists;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Microsoft.EntityFrameworkCore;
using static Application.Contacts.Messages.HospitalDiagnosisLists.BusinessMessages;

namespace Application.Services;

public class HospitalDiagnosisListService : IHospitalDiagnosisListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HospitalDiagnosisListService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void CreateHospitalDiagnosisList(CreateHospitalDiagnosisListRequest request)
    {
        CheckIcHospitalDiagnosisListExistsByName(request.LabaratoryName);

        var hospitalDiagnosisList = _mapper.Map<HospitalDiagnosisList>(request);

        _unitOfWork.HospitalDiagnosisListRepository.Create(hospitalDiagnosisList);
        _unitOfWork.SaveChanges();
    }

    public void UpdateHospitalDiagnosisListContact(Guid id, UpdateHospitalDiagnosisListContactRequest request)
    {
        var hospitalDiagnosisList = GetHospitalDiagnosisListEntity(id);

        if (!string.Equals(hospitalDiagnosisList.LabaratoryName, request.LabaratoryName,
                StringComparison.OrdinalIgnoreCase))
        {
            CheckIcHospitalDiagnosisListExistsByName(request.LabaratoryName);
        }
        
        var updatedHospitalDiagnosisList = _mapper.Map(request, hospitalDiagnosisList);
        
        _unitOfWork.HospitalDiagnosisListRepository.Update(updatedHospitalDiagnosisList);
        _unitOfWork.SaveChanges();
    }

    public void DeleteHospitalDiagnosisList(Guid id)
    {
        var hospitalDiagnosisList = GetHospitalDiagnosisListEntity(id);
        
        _unitOfWork.HospitalDiagnosisListRepository.Delete(hospitalDiagnosisList);
        _unitOfWork.SaveChanges();
    }

    public HospitalDiagnosisListResponse GetHospitalDiagnosisListById(Guid id)
    {
        var hospitalDiagnosisList = GetHospitalDiagnosisListEntity(id);
        
        return _mapper.Map<HospitalDiagnosisListResponse>(hospitalDiagnosisList);
    }

    public List<HospitalDiagnosisListResponse> GetAllHospitalDiagnosisLists()
    {
        var hospitalDiagnosisLists = _unitOfWork.HospitalDiagnosisListRepository.GetAll(
            include: source => source
                .Include(x => x.PatientDiagnoses)
        );
        
        return hospitalDiagnosisLists.Any() 
            ? _mapper.Map<List<HospitalDiagnosisListResponse>>(hospitalDiagnosisLists) 
            : throw new NotFoundException(HospitalDiagnosisListNotFound);
    }

    public HospitalDiagnosisList GetHospitalDiagnosisListEntity(Guid id)
    {
        var hospitalDiagnosisList = _unitOfWork.HospitalDiagnosisListRepository.Get(
            predicate: x => x.Id.Equals(id),
            include: source => source
                .Include(x => x.PatientDiagnoses)
        );

        return hospitalDiagnosisList ?? throw new NotFoundException(HospitalDiagnosisListNotFoundById);
    }

    private void CheckIcHospitalDiagnosisListExistsByName(string name)
    {
        var hospitalDiagnosisList = _unitOfWork.HospitalDiagnosisListRepository.Get(
            predicate: x => x.LabaratoryName.Equals(name)
        );

        if (hospitalDiagnosisList is not null) throw new BusinessException(HospitalDiagnosisListAlreadyExists);
    }
}
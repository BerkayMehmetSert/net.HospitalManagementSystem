using Application.Contacts.Repositories;
using Application.Contacts.Requests.EmergencyContacts;
using Application.Contacts.Responses.EmergencyContacts;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Microsoft.EntityFrameworkCore;
using static Application.Contacts.Messages.EmergencyContacts.BusinessMessages;

namespace Application.Services;

public class EmergencyContactService : IEmergencyContactService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmergencyContactService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void CreateEmergencyContact(CreateEmergencyContactRequest request)
    {
        CheckIfEmergencyContactExistsByEmail(request.Email);

        var emergencyContact = _mapper.Map<EmergencyContact>(request);

        _unitOfWork.EmergencyContactRepository.Create(emergencyContact);
        _unitOfWork.SaveChanges();
    }

    public void UpdateEmergency(Guid id, UpdateEmergencyRequest request)
    {
        var emergencyContact = GetEmergencyContactEntity(id);

        var updatedEmergencyContact = _mapper.Map(request, emergencyContact);

        _unitOfWork.EmergencyContactRepository.Update(updatedEmergencyContact);
        _unitOfWork.SaveChanges();
    }

    public void UpdateEmergencyContact(Guid id, UpdateEmergencyContactRequest request)
    {
        var emergencyContact = GetEmergencyContactEntity(id);

        if (emergencyContact.Email != request.Email) CheckIfEmergencyContactExistsByEmail(request.Email);

        var updatedEmergencyContact = _mapper.Map(request, emergencyContact);

        _unitOfWork.EmergencyContactRepository.Update(updatedEmergencyContact);
        _unitOfWork.SaveChanges();
    }

    public void UpdateEmergencyContactRelationship(Guid id, UpdateEmergencyContactRelationshipRequest request)
    {
        var emergencyContact = GetEmergencyContactEntity(id);

        var updatedEmergencyContact = _mapper.Map(request, emergencyContact);

        _unitOfWork.EmergencyContactRepository.Update(updatedEmergencyContact);
        _unitOfWork.SaveChanges();
    }

    public void DeleteEmergencyContact(Guid id)
    {
        var emergencyContact = GetEmergencyContactEntity(id);

        _unitOfWork.EmergencyContactRepository.Delete(emergencyContact);
        _unitOfWork.SaveChanges();
    }

    public EmergencyContactResponse GetEmergencyContactById(Guid id)
    {
        var emergencyContact = GetEmergencyContactEntity(id);

        return _mapper.Map<EmergencyContactResponse>(emergencyContact);
    }

    public EmergencyContactResponse GetEmergencyContactByFirstNameAndLastName(string firstName, string lastName)
    {
        var emergencyContact = _unitOfWork.EmergencyContactRepository.Get(
            predicate: x =>
                x.FirstName.Equals(firstName, StringComparison.Ordinal) &&
                x.LastName.Equals(lastName, StringComparison.Ordinal),
            include: source => source
                .Include(x => x.Patients)
        );

        return emergencyContact is not null
            ? _mapper.Map<EmergencyContactResponse>(emergencyContact)
            : throw new NotFoundException(EmergencyContactNotFoundByFirstNameAndLastName);
    }

    public List<EmergencyContactResponse> GetAllEmergencyContacts()
    {
        var emergencyContacts = _unitOfWork.EmergencyContactRepository.GetAll(
            include: source => source
                .Include(x => x.Patients)
        );

        return emergencyContacts.Any()
            ? _mapper.Map<List<EmergencyContactResponse>>(emergencyContacts)
            : throw new NotFoundException(EmergencyContactListIsEmpty);
    }

    public EmergencyContact GetEmergencyContactEntity(Guid id)
    {
        var emergencyContact = _unitOfWork.EmergencyContactRepository.Get(
            predicate: x => x.Id.Equals(id),
            include: source => source
                .Include(x => x.Patients)
        );

        return emergencyContact ?? throw new NotFoundException(EmergencyContactNotFoundById);
    }

    private void CheckIfEmergencyContactExistsByEmail(string email)
    {
        var emergencyContact = _unitOfWork.EmergencyContactRepository.Get(
            predicate: x => x.Email.Equals(email)
        );

        if (emergencyContact is not null) throw new BusinessException(EmergencyContactAlreadyExistsByEmail);
    }
}
using Application.Contacts.Requests.EmergencyContacts;
using Application.Contacts.Responses.EmergencyContacts;
using Domain.Entities;

namespace Application.Contacts.Services;

public interface IEmergencyContactService
{
    void CreateEmergencyContact(CreateEmergencyContactRequest request);
    void UpdateEmergency(Guid id, UpdateEmergencyRequest request);
    void UpdateEmergencyContact(Guid id, UpdateEmergencyContactRequest request);
    void UpdateEmergencyContactRelationship(Guid id, UpdateEmergencyContactRelationshipRequest request);
    void DeleteEmergencyContact(Guid id);
    EmergencyContactResponse GetEmergencyContactById(Guid id);
    EmergencyContactResponse GetEmergencyContactByFirstNameAndLastName(string firstName, string lastName);
    List<EmergencyContactResponse> GetAllEmergencyContacts();
    EmergencyContact GetEmergencyContactEntity(Guid id);
}
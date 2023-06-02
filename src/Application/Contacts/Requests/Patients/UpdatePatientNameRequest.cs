namespace Application.Contacts.Requests.Patients;

public class UpdatePatientNameRequest : BaseRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
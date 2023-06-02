namespace Application.Contacts.Requests.Patients;

public class UpdatePatientContactRequest : BaseRequest
{
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
namespace Application.Contacts.Requests.Doctors;

public class UpdateDoctorRequest : BaseRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
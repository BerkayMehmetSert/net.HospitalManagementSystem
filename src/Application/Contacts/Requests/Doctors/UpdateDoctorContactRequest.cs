namespace Application.Contacts.Requests.Doctors;

public class UpdateDoctorContactRequest : BaseRequest
{
    public string Phone { get; set; }
    public string Email { get; set; }
}
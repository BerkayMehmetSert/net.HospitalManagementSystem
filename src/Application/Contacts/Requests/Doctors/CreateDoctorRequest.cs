namespace Application.Contacts.Requests.Doctors;

public class CreateDoctorRequest : BaseRequest
{
    public Guid DepartmentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
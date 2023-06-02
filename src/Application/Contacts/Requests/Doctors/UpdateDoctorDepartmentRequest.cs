namespace Application.Contacts.Requests.Doctors;

public class UpdateDoctorDepartmentRequest : BaseRequest
{
    public Guid DepartmentId { get; set; }
}
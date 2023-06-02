namespace Application.Contacts.Requests.Departments;

public class UpdateDepartmentContactRequest : BaseRequest
{
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
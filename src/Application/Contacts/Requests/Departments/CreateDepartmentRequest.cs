namespace Application.Contacts.Requests.Departments;

public class CreateDepartmentRequest : BaseRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Notes { get; set; }
}
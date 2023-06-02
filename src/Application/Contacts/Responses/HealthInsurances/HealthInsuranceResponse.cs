namespace Application.Contacts.Responses.HealthInsurances;

public class HealthInsuranceResponse : BaseResponse
{
    public string CompanyName { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Postcode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
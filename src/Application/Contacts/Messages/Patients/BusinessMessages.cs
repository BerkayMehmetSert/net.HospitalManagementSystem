namespace Application.Contacts.Messages.Patients;

public static class BusinessMessages
{
    public const string PatientAlreadyExistsByEmail = "Patient already exists by email";

    public const string HealthInsuranceAlreadyExistsByCompanyName =
        "Patient health insurance already exists by company name";

    public const string PatientNotFoundById = "Patient not found by id";
    public const string PatientListIsEmpty = "Patient list is empty";
    public const string PatientNotFoundByFirstNameAndLastName = "Patient not found by first name and last name";
}
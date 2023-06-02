using Application.Contacts.Requests.Patients;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _service;

    public PatientController(IPatientService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreatePatient([FromBody] CreatePatientRequest request)
    {
        _service.CreatePatient(request);
        return Ok();
    }

    [HttpPut("{id}/Contact")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdatePatientContact([FromRoute] Guid id, [FromBody] UpdatePatientContactRequest request)
    {
        _service.UpdatePatientContact(id, request);
        return Ok();
    }

    [HttpPut("{id}/EmergencyContact")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdatePatientEmergencyContact([FromRoute] Guid id,
        [FromBody] UpdatePatientEmergencyContactRequest request)
    {
        _service.UpdatePatientEmergencyContact(id, request);
        return Ok();
    }

    [HttpPut("{id}/Name")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdatePatientName([FromRoute] Guid id, [FromBody] UpdatePatientNameRequest request)
    {
        _service.UpdatePatientName(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeletePatient([FromRoute] Guid id)
    {
        _service.DeletePatient(id);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetPatientById([FromRoute] Guid id)
    {
        var result = _service.GetPatientById(id);
        return Ok(result);
    }

    [HttpGet("Name/{firstName}/{lastName}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetPatientByFirstNameAndLastName([FromRoute] string firstName, [FromRoute] string lastName)
    {
        var result = _service.GetPatientByFirstNameAndLastName(firstName, lastName);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllPatients()
    {
        var result = _service.GetAllPatients();
        return Ok(result);
    }
}
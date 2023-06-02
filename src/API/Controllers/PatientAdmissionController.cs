using Application.Contacts.Requests.PatientAdmissions;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientAdmissionController : ControllerBase
{
    private readonly IPatientAdmissionService _service;

    public PatientAdmissionController(IPatientAdmissionService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreatePatientAdmission([FromBody] CreatePatientAdmissionRequest request)
    {
        _service.CreatePatientAdmission(request);
        return Ok();
    }

    [HttpPut("{id}/numbers")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdatePatientAdmissionNumbers([FromRoute] Guid id,
        [FromBody] UpdatePatientAdmissionNumbersRequest request)
    {
        _service.UpdatePatientAdmissionNumber(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeletePatientAdmission([FromRoute] Guid id)
    {
        _service.DeletePatientAdmission(id);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetPatientAdmissionById([FromRoute] Guid id)
    {
        var result = _service.GetPatientAdmissionById(id);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllPatientAdmissions()
    {
        var result = _service.GetAllPatientAdmissions();
        return Ok(result);
    }
}
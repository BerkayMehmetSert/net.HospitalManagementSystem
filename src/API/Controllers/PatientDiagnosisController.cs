using Application.Contacts.Requests.PatientDiagnoses;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientDiagnosisController : ControllerBase
{
    private readonly IPatientDiagnosisService _service;

    public PatientDiagnosisController(IPatientDiagnosisService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreatePatientDiagnosis([FromBody] CreatePatientDiagnosisRequest request)
    {
        _service.CreatePatientDiagnosis(request);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin , User")]
    public IActionResult GetPatientDiagnosisById([FromRoute] Guid id)
    {
        var result = _service.GetPatientDiagnosisById(id);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin , User")]
    public IActionResult GetAllPatientDiagnoses()
    {
        var result = _service.GetAllPatientDiagnoses();
        return Ok(result);
    }
}
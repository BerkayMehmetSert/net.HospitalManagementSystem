using Application.Contacts.Requests.PatientFollowUps;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientFollowUpController : ControllerBase
{
    private readonly IPatientFollowUpService _service;

    public PatientFollowUpController(IPatientFollowUpService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreatePatientFollowUp([FromBody] CreatePatientFollowUpRequest request)
    {
        _service.CreatePatientFollowUp(request);
        return Ok();
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetPatientFollowUpById([FromRoute] Guid id)
    {
        var result = _service.GetPatientFollowUpById(id);
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllPatientFollowUps()
    {
        var result = _service.GetAllPatientFollowUps();
        return Ok(result);
    }
}
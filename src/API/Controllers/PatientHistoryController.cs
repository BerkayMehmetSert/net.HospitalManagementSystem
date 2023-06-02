using Application.Contacts.Requests.PatientHistories;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientHistoryController : ControllerBase
{
    private readonly IPatientHistoryService _service;

    public PatientHistoryController(IPatientHistoryService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreatePatientHistory([FromBody] CreatePatientHistoryRequest request)
    {
        _service.CreatePatientHistory(request);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetPatientHistoryById([FromRoute] Guid id)
    {
        var result = _service.GetPatientHistoryById(id);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllPatientHistories()
    {
        var result = _service.GetAllPatientHistories();
        return Ok(result);
    }

    [HttpGet("OrderByDateOfVisit")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllPatientHistoriesOrderByDateOfVisit()
    {
        var result = _service.GetAllPatientHistoriesOrderByDateOfVisit();
        return Ok(result);
    }
}
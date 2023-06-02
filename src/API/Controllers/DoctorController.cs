using Application.Contacts.Requests.Doctors;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _service;

    public DoctorController(IDoctorService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateDoctor([FromBody] CreateDoctorRequest request)
    {
        _service.CreateDoctor(request);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateDoctor([FromRoute] Guid id, [FromBody] UpdateDoctorRequest request)
    {
        _service.UpdateDoctor(id, request);
        return Ok();
    }

    [HttpPut("{id}/contact")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateDoctorContact([FromRoute] Guid id, [FromBody] UpdateDoctorContactRequest request)
    {
        _service.UpdateDoctorContact(id, request);
        return Ok();
    }

    [HttpPut("{id}/department")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateDoctorDepartment([FromRoute] Guid id, [FromBody] UpdateDoctorDepartmentRequest request)
    {
        _service.UpdateDoctorDepartment(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteDoctor([FromRoute] Guid id)
    {
        _service.DeleteDoctor(id);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetDoctorById([FromRoute] Guid id)
    {
        var result = _service.GetDoctorById(id);
        return Ok(result);
    }

    [HttpGet("name/{firstName}/{lastName}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetDoctorByFirstNameAndLastName([FromRoute] string firstName, [FromRoute] string lastName)
    {
        var result = _service.GetDoctorByFirstNameAndLastName(firstName, lastName);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllDoctors()
    {
        var result = _service.GetAllDoctors();
        return Ok(result);
    }
}
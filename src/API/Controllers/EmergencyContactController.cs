using Application.Contacts.Requests.EmergencyContacts;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmergencyContactController : ControllerBase
{
    private readonly IEmergencyContactService _service;

    public EmergencyContactController(IEmergencyContactService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateEmergencyContact([FromBody] CreateEmergencyContactRequest request)
    {
        _service.CreateEmergencyContact(request);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateEmergency([FromRoute] Guid id, [FromBody] UpdateEmergencyRequest request)
    {
        _service.UpdateEmergency(id, request);
        return Ok();
    }

    [HttpPut("{id}/contact")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateEmergencyContact([FromRoute] Guid id, [FromBody] UpdateEmergencyContactRequest request)
    {
        _service.UpdateEmergencyContact(id, request);
        return Ok();
    }

    [HttpPut("{id}/relationship")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateEmergencyContactRelationship([FromRoute] Guid id,
        [FromBody] UpdateEmergencyContactRelationshipRequest request)
    {
        _service.UpdateEmergencyContactRelationship(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteEmergencyContact([FromRoute] Guid id)
    {
        _service.DeleteEmergencyContact(id);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetEmergencyContactById([FromRoute] Guid id)
    {
        var result = _service.GetEmergencyContactById(id);
        return Ok(result);
    }

    [HttpGet("name/{firstName}/{lastName}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetEmergencyContactByFirstNameAndLastName([FromRoute] string firstName,
        [FromRoute] string lastName)
    {
        var result = _service.GetEmergencyContactByFirstNameAndLastName(firstName, lastName);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllEmergencyContacts()
    {
        var result = _service.GetAllEmergencyContacts();
        return Ok(result);
    }
}
using Application.Contacts.Requests.Departments;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;

    public DepartmentController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateDepartment([FromBody] CreateDepartmentRequest request)
    {
        _service.CreateDepartment(request);
        return Ok();
    }

    [HttpPut("{id}/contact")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateDepartmentContact([FromRoute] Guid id, [FromBody] UpdateDepartmentContactRequest request)
    {
        _service.UpdateDepartmentContact(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteDepartment([FromRoute] Guid id)
    {
        _service.DeleteDepartment(id);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetDepartmentById([FromRoute] Guid id)
    {
        var result = _service.GetDepartmentById(id);

        return Ok(result);
    }

    [HttpGet("name/{name}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetDepartmentByName([FromRoute] string name)
    {
        var result = _service.GetDepartmentByName(name);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllDepartments()
    {
        var result = _service.GetAllDepartments();
        return Ok(result);
    }
}
using Application.Contacts.Requests.HospitalDiagnosisLists;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HospitalDiagnosisListController : ControllerBase
{
    private readonly IHospitalDiagnosisListService _service;

    public HospitalDiagnosisListController(IHospitalDiagnosisListService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateHospitalDiagnosisList([FromBody] CreateHospitalDiagnosisListRequest request)
    {
        _service.CreateHospitalDiagnosisList(request);
        return Ok();
    }

    [HttpPut("{id}/contact")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateHospitalDiagnosisListContact([FromRoute] Guid id,
        [FromBody] UpdateHospitalDiagnosisListContactRequest request)
    {
        _service.UpdateHospitalDiagnosisListContact(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteHospitalDiagnosisList([FromRoute] Guid id)
    {
        _service.DeleteHospitalDiagnosisList(id);
        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetHospitalDiagnosisListById([FromRoute] Guid id)
    {
        var result = _service.GetHospitalDiagnosisListById(id);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllHospitalDiagnosisLists()
    {
        var result = _service.GetAllHospitalDiagnosisLists();
        return Ok(result);
    }
}
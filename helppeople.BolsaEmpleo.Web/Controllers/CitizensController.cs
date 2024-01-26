using helppeople.BolsaEmpleo.Application.Common.Exceptions;
using helppeople.BolsaEmpleo.Application.DTO;
using helppeople.BolsaEmpleo.Application.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace helppeople.BolsaEmpleo.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitizensController : ControllerBase
{
    private readonly ICitizensService _citizensService;

    public CitizensController(ICitizensService citizensService)
    {
        _citizensService = citizensService;
    }

    [HttpGet("GetIdDocumentTypes")]
    public async Task<IActionResult> GetIdDocumentTypes()
    {
        try
        {
            var result = await _citizensService.GetIdDocumentTypes();
            return Ok(result);
        }
        catch (NoIdDocumentTypesFound)
        {
            return Problem("There is no Id document types on database");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCitizens()
    {
        var citizens = await _citizensService.GetAll();
        return Ok(citizens);
    }

    [HttpGet("{citizenId:int}")]
    public async Task<IActionResult> GetById(int citizenId)
    {
        try
        {
            var citizen = await _citizensService.GetById(citizenId);
            return Ok(citizen);
        }
        catch (CitizenNotFound)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCitizen(CreateCitizenDto createCitizenDto)
    {
        try
        {
            var citizen = await _citizensService.RegisterCitizen(createCitizenDto);
            return Ok(citizen);
        }
        catch (NoIdDocumentTypesFound)
        {
            return BadRequest("Invalid documentTypeId");
        }
        catch (CitizenWithSpecifiedIdNumberAlreadyExists)
        {
            return BadRequest("A citizen with that id number is already registered");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCitizen(UpdateCitizenDto updateCitizenDto)
    {
        try
        {
            var citizen = await _citizensService.UpdateCitizen(updateCitizenDto);
            return Ok(citizen);
        }
        catch (CitizenNotFound)
        {
            return NotFound("Citizen not found");
        }
    }

    [HttpDelete("{citizenId:int}")]
    public async Task<IActionResult> DeleteCitizen(int citizenId)
    {
        try
        {
            await _citizensService.DeleteCitizen(citizenId);
            return Ok();
        }
        catch
        {
            return Problem();
        }
    }
}
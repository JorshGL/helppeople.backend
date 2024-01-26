using helppeople.BolsaEmpleo.Application.Common.Exceptions;
using helppeople.BolsaEmpleo.Application.DTO;
using helppeople.BolsaEmpleo.Application.Services.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace helppeople.BolsaEmpleo.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacanciesController : ControllerBase
{
    private readonly IVacanciesService _vacanciesService;
    
    public VacanciesController(IVacanciesService vacanciesService)
    {
        _vacanciesService = vacanciesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vacancies = await _vacanciesService.GetAll();
        return Ok(vacancies);
    }

    [HttpPost("Apply")]
    public async Task<IActionResult> Apply(VacancyApplicationDto vacancyApplicationDto)
    {
        try
        {
            var vacancy = await _vacanciesService.Apply(vacancyApplicationDto.VacancyId, vacancyApplicationDto.UserId);
            return Ok(vacancy);
        }
        catch (CitizenNotFound)
        {
            return NotFound("Citizen not found");
        }
        catch (VacancyNotFound)
        {
            return NotFound("Vacancy not found");
        }
    }
}
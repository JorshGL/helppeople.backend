using helppeople.BolsaEmpleo.Application.Common.Exceptions;
using helppeople.BolsaEmpleo.Application.Services.interfaces;
using helppeople.BolsaEmpleo.Domain.Entities;
using helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Interfaces;

namespace helppeople.BolsaEmpleo.Application.Services.implementations;

public class VacanciesService : IVacanciesService
{
    private readonly IVacanciesRepository _vacanciesRepository;
    private readonly ICitizensService _citizensService;

    public VacanciesService(IVacanciesRepository vacanciesRepository, ICitizensService citizensService)
    {
        _vacanciesRepository = vacanciesRepository;
        _citizensService = citizensService;
    }
    
    public async Task<ICollection<Vacancy>> GetAll()
    {
        return await _vacanciesRepository.GetAll(v => v.Citizen);
    }

    public async Task<Vacancy> Apply(int vacancyId, int userId)
    {
        var citizen = await _citizensService.GetById(userId);
        var vacancy = await _vacanciesRepository.FindById(vacancyId);
        if (vacancy == null)
        {
            throw new VacancyNotFound();
        }
        vacancy.Citizen = citizen;
        return await _vacanciesRepository.Update(vacancy);
    }
}
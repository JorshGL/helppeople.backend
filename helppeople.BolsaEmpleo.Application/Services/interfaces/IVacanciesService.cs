using helppeople.BolsaEmpleo.Domain.Entities;

namespace helppeople.BolsaEmpleo.Application.Services.interfaces;

public interface IVacanciesService
{
    public Task<ICollection<Vacancy>> GetAll();

    public Task<Vacancy> Apply(int vacancyId, int userId);
}
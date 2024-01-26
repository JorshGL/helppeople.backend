using helppeople.BolsaEmpleo.Domain.Common;
using helppeople.BolsaEmpleo.Domain.Entities;
using helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Interfaces;

namespace helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Implementations;

public class VacanciesRepository : BaseRepository<Vacancy, BolsaEmpleoDBContext>, IVacanciesRepository
{
    public VacanciesRepository(BolsaEmpleoDBContext dbContext) : base(dbContext)
    {
    }
}
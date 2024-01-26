using helppeople.BolsaEmpleo.Domain.Common;
using helppeople.BolsaEmpleo.Domain.Entities;
using helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Interfaces;

namespace helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Implementations;

public class CitizensRepository : BaseRepository<Citizen, BolsaEmpleoDBContext>, ICitizensRepository
{
    public CitizensRepository(BolsaEmpleoDBContext dbContext) : base(dbContext)
    {
    }
}
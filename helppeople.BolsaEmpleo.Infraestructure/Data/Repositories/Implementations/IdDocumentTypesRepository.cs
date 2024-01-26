using helppeople.BolsaEmpleo.Domain.Common;
using helppeople.BolsaEmpleo.Domain.Entities;
using helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Interfaces;

namespace helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Implementations;

public class IdDocumentTypesRepository : BaseRepository<IdDocumentType, BolsaEmpleoDBContext>, IIdDocumentTypesRepository
{
    public IdDocumentTypesRepository(BolsaEmpleoDBContext dbContext) : base(dbContext)
    {
    }
}
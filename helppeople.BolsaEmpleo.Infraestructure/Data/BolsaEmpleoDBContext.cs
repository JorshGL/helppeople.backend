using helppeople.BolsaEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace helppeople.BolsaEmpleo.Infraestructure.Data;

public class BolsaEmpleoDBContext : DbContext
{
    public DbSet<Citizen> Citizens { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<IdDocumentType> IdDocumentTypes { get; set; }

    public BolsaEmpleoDBContext(DbContextOptions<BolsaEmpleoDBContext> options) : base(options)
    {
    }
}
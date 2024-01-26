using helppeople.BolsaEmpleo.Domain.Common;

namespace helppeople.BolsaEmpleo.Domain.Entities;

public class Citizen : BaseEntity
{
    public virtual IdDocumentType IdDocumentType { get; set; }
    
    public string IdNumber { get; set; }
    
    public string Name { get; set; }
    
    public string LastName { get; set; }
    
    public DateOnly BirthDate { get; set; }
    
    public string Profession { get; set; }
    
    public float SalaryAspiration { get; set; }
    
    public string Email { get; set; }
}

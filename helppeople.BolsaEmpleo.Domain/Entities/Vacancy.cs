using helppeople.BolsaEmpleo.Domain.Common;

namespace helppeople.BolsaEmpleo.Domain.Entities;

public class Vacancy : BaseEntity
{
    public string Code { get; set; }

    public string Position { get; set; }
    
    public string Description { get; set; }
    
    public string Company { get; set; }
    
    public string Salary { get; set; }
    
    public virtual Citizen? Citizen { get; set; }
}
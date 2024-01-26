namespace helppeople.BolsaEmpleo.Application.DTO;

public record UpdateCitizenDto(
    int Id,
    int DocumentTypeId,
    string IdNumber,
    string Name,
    string LastName,
    DateOnly BirthDate,
    string Profession,
    string SalaryAspiration,
    string Email);
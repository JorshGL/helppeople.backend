using helppeople.BolsaEmpleo.Domain.Entities;

namespace helppeople.BolsaEmpleo.Application.DTO;

public record CreateCitizenDto(
    int DocumentTypeId,
    string IdNumber,
    string Name,
    string LastName,
    DateOnly BirthDate,
    string Profession,
    string SalaryAspiration,
    string Email);
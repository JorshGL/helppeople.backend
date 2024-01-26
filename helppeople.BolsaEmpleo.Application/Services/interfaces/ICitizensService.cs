using helppeople.BolsaEmpleo.Application.DTO;
using helppeople.BolsaEmpleo.Domain.Entities;

namespace helppeople.BolsaEmpleo.Application.Services.interfaces;

public interface ICitizensService
{
    public Task<ICollection<IdDocumentType>> GetIdDocumentTypes();

    public Task<ICollection<Citizen>> GetAll();
    
    public Task<Citizen> RegisterCitizen(CreateCitizenDto createCitizenDto);

    public Task<Citizen> UpdateCitizen(UpdateCitizenDto updateCitizenDto);
}
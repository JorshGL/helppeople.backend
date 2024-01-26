using AutoMapper;
using helppeople.BolsaEmpleo.Application.Common.Exceptions;
using helppeople.BolsaEmpleo.Application.DTO;
using helppeople.BolsaEmpleo.Application.Services.interfaces;
using helppeople.BolsaEmpleo.Domain.Entities;
using helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Interfaces;

namespace helppeople.BolsaEmpleo.Application.Services.implementations;

public class CitizensService : ICitizensService
{
    private readonly IIdDocumentTypesRepository _idDocumentTypesRepository;
    private readonly ICitizensRepository _citizensRepository;
    private readonly IMapper _mapper;

    public CitizensService(IIdDocumentTypesRepository idDocumentTypesRepository, ICitizensRepository citizensRepository,
        IMapper mapper)
    {
        _idDocumentTypesRepository = idDocumentTypesRepository;
        _citizensRepository = citizensRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<IdDocumentType>> GetIdDocumentTypes()
    {
        var idDocumentTypes = await _idDocumentTypesRepository.GetAll();
        if (!idDocumentTypes.Any()) throw new NoIdDocumentTypesFound();
        return idDocumentTypes;
    }

    public async Task<ICollection<Citizen>> GetAll()
    {
        return await _citizensRepository.GetAll(c => c.IdDocumentType);
    }

    public async Task<Citizen> RegisterCitizen(CreateCitizenDto createCitizenDto)
    {
        var citizen = _mapper.Map<Citizen>(createCitizenDto);
        var documentType = await _idDocumentTypesRepository.FindById(createCitizenDto.DocumentTypeId);
        if (documentType == null)
        {
            throw new NoIdDocumentTypesFound();
        }

        citizen.IdDocumentType = documentType;
        return await _citizensRepository.Save(citizen);
    }

    public async Task<Citizen> UpdateCitizen(UpdateCitizenDto updateCitizenDto)
    {
        var currentCitizen = await _citizensRepository.FindById(updateCitizenDto.Id);
        if (currentCitizen == null)
        {
            throw new CitizenNotFound();
        }

        currentCitizen = _mapper.Map<Citizen>(updateCitizenDto);
        var documentType = await _idDocumentTypesRepository.FindById(updateCitizenDto.DocumentTypeId);
        if (documentType == null)
        {
            throw new NoIdDocumentTypesFound();
        }

        currentCitizen.IdDocumentType = documentType;
        return await _citizensRepository.Update(currentCitizen);
    }
}
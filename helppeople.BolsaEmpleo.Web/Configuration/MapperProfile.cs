using AutoMapper;
using helppeople.BolsaEmpleo.Application.DTO;
using helppeople.BolsaEmpleo.Domain.Entities;

namespace helppeople.BolsaEmpleo.Application.Utils;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateCitizenDto, Citizen>()
            .ForMember(c => c.IdDocumentType,
                opt => opt.AllowNull());
        CreateMap<UpdateCitizenDto, Citizen>()
            .ForMember(c => c.IdDocumentType, 
                opt => opt.AllowNull());
    }
}
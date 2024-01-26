using AutoMapper;
using helppeople.BolsaEmpleo.Application.DTO;
using helppeople.BolsaEmpleo.Domain.Entities;

namespace helppeople.BolsaEmpleo.Application.Utils;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateCitizenDto, Citizen>()
            .ForSourceMember(dto => dto.DocumentTypeId, 
                opt => opt.DoNotValidate());
        CreateMap<UpdateCitizenDto, Citizen>()
            .ForMember(c => c.IdNumber,
                opt => opt.Ignore());
    }
}
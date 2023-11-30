using AutoMapper;
using SSDB_Lab4.Common.DTOs.Division;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.MappingProfiles;

public class DivisionMappingProfile: Profile
{
    public DivisionMappingProfile()
    {
        CreateMap<Division, DivisionDto>();
        CreateMap<CreateDivisionDto, Division>();
        CreateMap<UpdateDivisionDto, Division>();
    }
}
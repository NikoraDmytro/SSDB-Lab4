using AutoMapper;
using SSDB_Lab4.Common.DTOs.Sportsman;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.MappingProfiles;

public class SportsmanMappingProfile: Profile
{
    public SportsmanMappingProfile()
    {
        CreateMap<Sportsman, SportsmanDto>()
            .ForMember(s => s.FullName,
                opt => opt.MapFrom(
                    src => $"{src.LastName} {src.FirstName}"));
        
        CreateMap<CreateSportsmanDto, Sportsman>();
        CreateMap<UpdateSportsmanDto, Sportsman>();
    }
}
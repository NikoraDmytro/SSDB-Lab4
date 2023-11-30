using AutoMapper;
using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.MappingProfiles;

public class CompetitorMappingProfile: Profile
{
    public CompetitorMappingProfile()
    {
        CreateProjection<Competitor, CompetitorDto>()
            .ForMember(c => c.Division,
                conf => conf.MapFrom(
                    src => src.Division != null ? src.Division.Name : null))
            .ForMember(c => c.FullName,
                conf => conf.MapFrom(
                    src => $"{src.Sportsman!.LastName} {src.Sportsman.FirstName}"))
            .ForMember(c => c.BirthDate,
                conf => conf.MapFrom(
                    src => src.Sportsman!.BirthDate))
            .ForMember(c => c.Sex,
                conf => conf.MapFrom(
                    src => src.Sportsman!.Sex));
        
        CreateMap<CreateCompetitorDto, Competitor>();
    }
}
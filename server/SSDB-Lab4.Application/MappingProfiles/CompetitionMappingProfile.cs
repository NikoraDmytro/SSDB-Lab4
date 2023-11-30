using AutoMapper;
using SSDB_Lab4.Common.DTOs.Competition;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.MappingProfiles;

public class CompetitionMappingProfile: Profile
{
    public CompetitionMappingProfile()
    {
        CreateMap<Competition, CompetitionDto>();
        CreateMap<CreateCompetitionDto, Competition>();
        CreateMap<UpdateCompetitionDto, Competition>();
    }
}
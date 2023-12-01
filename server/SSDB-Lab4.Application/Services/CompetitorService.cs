using AutoMapper;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.Exceptions;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.Services
{
    public class CompetitorService : BaseService, ICompetitorService
    {
        public CompetitorService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        private async Task<Competitor> FindCompetitorAsync(int id)
        {
            var competitor = await UnitOfWork
                .CompetitorRepository
                .GetByIdAsync(id);

            if (competitor is null)
            {
                throw new NotFoundException($"Competitor was not found!");
            }

            return competitor;
        }

        private async Task ThrowIfDuplicate(int competitionId, IEnumerable<int> sportsmenIds)
        {
            var duplicate = await UnitOfWork
                .CompetitorRepository
                .GetBySportsmenIds(competitionId, sportsmenIds);
            var duplicateArr = duplicate
                .Select(d => d.SportsmanId)
                .ToArray();
            
            if (duplicateArr.Length != 0)
            {
                String ids = string.Join(", ", duplicateArr);
                throw new BadRequestException($"Sportsmen with ids [{ids}] are already registered on competition!");
            }
        }

        private async Task ThrowIfNotFound(IEnumerable<int> sportsmenIds)
        {
            var sportsmenIdsArr = sportsmenIds.ToArray();
            var notFound = await UnitOfWork
                .SportsmanRepository
                .GetByIdsAsync(sportsmenIdsArr);
            var notFoundArr = sportsmenIdsArr
                .Except(notFound.Select(s => s.Id))
                .ToArray();

            if (notFoundArr.Length != 0)
            {
                String ids = string.Join(", ", notFoundArr);
                throw new BadRequestException($"Sportsmen with ids [{ids}] not found!");
            }
        }

        private IQueryable<CompetitorDto> ProjectQueryable(
            IQueryable<Competitor> queryable)
        {
            return Mapper.ProjectTo<CompetitorDto>(queryable);
        }

        public async Task<PagedList<CompetitorDto>> GetCompetitorsAsync(
            int competitionId,
            RequestParameters parameters)
        {
            var competitorsDto = await UnitOfWork
                .CompetitorRepository
                .GetAllPagedMappedAsync(
                    competitionId,
                    parameters,
                    ProjectQueryable);

            return competitorsDto;
        }

        public async Task<CompetitorDto?> GetCompetitorByIdAsync(int id)
        {
            var competitorDto = await UnitOfWork
                .CompetitorRepository
                .GetByIdMappedAsync(id, ProjectQueryable);

            if (competitorDto is null)
            {
                throw new NotFoundException($"Competitor was not found!");
            }
            
            return competitorDto;
        }

        public async Task CreateCompetitorsCollectionAsync(
            int competitionId,
            IEnumerable<CreateCompetitorDto> createCompetitorDtos)
        {
            var sportsmanIds = createCompetitorDtos
                .Select(c => c.SportsmanId ?? 0)
                .ToArray();
            await ThrowIfDuplicate(competitionId, sportsmanIds);
            await ThrowIfNotFound(sportsmanIds);

            var competitors = Mapper
                .Map<IEnumerable<Competitor>>(createCompetitorDtos)
                .ToArray();
            
            foreach (var competitor in competitors)
            {
                competitor.CompetitionId = competitionId;
            }

            await UnitOfWork.CompetitorRepository.AddRangeAsync(competitors);
            await UnitOfWork.SaveAsync();
        }

        public async Task DeleteCompetitorAsync(int id)
        {
            var competitor = await FindCompetitorAsync(id);

            UnitOfWork.CompetitorRepository.Delete(competitor);
            await UnitOfWork.SaveAsync();
        }

        public async Task UpdateCompetitorAsync(
            int id, 
            UpdateCompetitorLapDto updateCompetitorLapDto)
        {
            var competitor = await FindCompetitorAsync(id);

            competitor.LapNum = updateCompetitorLapDto.LapNum ?? 0;
            
            UnitOfWork.CompetitorRepository.Update(competitor);
            await UnitOfWork.SaveAsync();
        }

        public async Task UpdateCompetitorAsync(
            int id, 
            UpdateCompetitorWeightDto updateCompetitorWeightDto)
        {
            var competitor = await FindCompetitorAsync(id);

            competitor.WeightingResult = updateCompetitorWeightDto.WeightingResult;
            
            UnitOfWork.CompetitorRepository.Update(competitor);
            await UnitOfWork.SaveAsync();
        }
    }
}

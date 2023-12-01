using Microsoft.AspNetCore.Mvc;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.API.Attributes;
using SSDB_Lab4.Common.Constants;
using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.RequestFeatures;

namespace SSDB_Lab4.API.Controllers
{
    [ApiController]
    [Route(Endpoints.Competitors.Base)]
    public class CompetitorsController : ControllerBase
    {
        private readonly ICompetitorService _competitorService;

        public CompetitorsController(ICompetitorService competitorService)
        {
            _competitorService = competitorService;
        }

        [HttpGet(Endpoints.Competitors.GetAll)]
        public async Task<IActionResult> GetAll(
            [FromRoute] int competitionId,
            [FromQuery] RequestParameters parameters)
        {
            var competitors = await _competitorService
                .GetCompetitorsAsync(competitionId, parameters);

            return Ok(competitors);
        }

        [HttpGet(Endpoints.Competitors.GetById, Name = "CompetitorById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var competitor = await _competitorService.GetCompetitorByIdAsync(id);

            return Ok(competitor);
        }

        [ValidateModel]
        [HttpPost(Endpoints.Competitors.Create)]
        public async Task<IActionResult> Create(
            [FromRoute] int competitionId, 
            IEnumerable<CreateCompetitorDto> createCompetitorDtos)
        {
            await _competitorService
                .CreateCompetitorsCollectionAsync(
                    competitionId, 
                    createCompetitorDtos);

            return NoContent();
        }

        [ValidateModel]
        [HttpPut(Endpoints.Competitors.SetWeight)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            UpdateCompetitorWeightDto updateCompetitorWeightDto)
        {
            await _competitorService
                .UpdateCompetitorAsync(id, updateCompetitorWeightDto);

            return NoContent();
        }

        [ValidateModel]
        [HttpPut(Endpoints.Competitors.SetLapNum)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            UpdateCompetitorLapDto updateCompetitorLapDto)
        {
            await _competitorService
                .UpdateCompetitorAsync(id, updateCompetitorLapDto);

            return NoContent();
        }

        [HttpDelete(Endpoints.Competitors.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _competitorService.DeleteCompetitorAsync(id);

            return NoContent();
        }
    }
}
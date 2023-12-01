using Microsoft.AspNetCore.Mvc;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.API.Attributes;
using SSDB_Lab4.Common.Constants;
using SSDB_Lab4.Common.DTOs.Competition;
using SSDB_Lab4.Common.RequestFeatures;

namespace SSDB_Lab4.API.Controllers
{
    [ApiController]
    [Route(Endpoints.Competitions.Base)]
    public class CompetitionsController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionsController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [HttpGet(Endpoints.Competitions.GetAll)]
        public async Task<IActionResult> GetAll(
            [FromQuery] RequestParameters parameters)
        {
            var competitions = await _competitionService
                .GetCompetitionsAsync(parameters);

            return Ok(competitions);
        }

        [HttpGet(Endpoints.Competitions.GetById, Name = "CompetitionById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var competition = await _competitionService.GetCompetitionByIdAsync(id);

            return Ok(competition);
        }

        [ValidateModel]
        [HttpPost(Endpoints.Competitions.Create)]
        public async Task<IActionResult> Create(CreateCompetitionDto createCompetitionDto)
        {
            var competition = await _competitionService
                .CreateCompetitionAsync(createCompetitionDto);

            return CreatedAtRoute(
                "CompetitionById",
                new { id = competition.Id },
                competition);
        }

        [ValidateModel]
        [HttpPut(Endpoints.Competitions.Update)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            UpdateCompetitionDto updateCompetitionDto)
        {
            await _competitionService.UpdateCompetitionAsync(id, updateCompetitionDto);

            return NoContent();
        }

        [HttpDelete(Endpoints.Competitions.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _competitionService.DeleteCompetitionAsync(id);

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.API.Attributes;
using SSDB_Lab4.Common.Constants;
using SSDB_Lab4.Common.DTOs.Division;

namespace SSDB_Lab4.API.Controllers
{
    [ApiController]
    [Route(Endpoints.Divisions.Base)]
    public class DivisionsController : ControllerBase
    {
        private readonly IDivisionService _divisionService;

        public DivisionsController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        [HttpGet(Endpoints.Divisions.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var divisions = await _divisionService.GetDivisionsAsync();

            return Ok(divisions);
        }

        [HttpGet(Endpoints.Divisions.GetById, Name = "DivisionById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var division = await _divisionService.GetDivisionByIdAsync(id);

            return Ok(division);
        }

        [ValidateModel]
        [HttpPost(Endpoints.Divisions.Create)]
        public async Task<IActionResult> Create(CreateDivisionDto createDivisionDto)
        {
            var division = await _divisionService
                .CreateDivisionAsync(createDivisionDto);

            return CreatedAtRoute(
                "DivisionById",
                new { id = division.Id },
                division);
        }

        [ValidateModel]
        [HttpPut(Endpoints.Divisions.Update)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            UpdateDivisionDto updateDivisionDto)
        {
            await _divisionService.UpdateDivisionAsync(id, updateDivisionDto);

            return NoContent();
        }

        [HttpDelete(Endpoints.Divisions.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _divisionService.DeleteDivisionAsync(id);

            return NoContent();
        }
    }
}

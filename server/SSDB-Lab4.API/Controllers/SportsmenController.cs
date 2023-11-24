using Microsoft.AspNetCore.Mvc;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.Common.Constants;
using SSDB_Lab4.Common.DTOs.Sportsman;

namespace SSDB_Lab4.API.Controllers;

[ApiController]
[Route(Endpoints.Sportsmen.Base)]
public class SportsmenController: ControllerBase
{
    private readonly ISportsmanService _sportsmanService;

    public SportsmenController(ISportsmanService sportsmanService)
    {
        _sportsmanService = sportsmanService;
    }

    [HttpGet(Endpoints.Sportsmen.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var sportsmen = await _sportsmanService.GetSportsmenAsync();
        
        return Ok(sportsmen);
    }
    
    [HttpGet(Endpoints.Sportsmen.GetById)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var sportsman = await _sportsmanService.GetSportsmanByIdAsync(id);
        
        return Ok(sportsman);
    }

    [HttpPost(Endpoints.Sportsmen.Create)]
    public async Task<IActionResult> Create(
        [FromBody] CreateSportsmanDto createSportsmanDto)
    {
        var sportsman = await _sportsmanService
            .CreateSportsmanAsync(createSportsmanDto);
        
        return CreatedAtRoute(
            nameof(GetById), 
            new { id = sportsman.Id }, 
            sportsman);
    }

    [HttpPut(Endpoints.Sportsmen.Update)]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] UpdateSportsmanDto updateSportsmanDto)
    {
        await _sportsmanService.UpdateSportsmanAsync(id, updateSportsmanDto);
        
        return NoContent();
    }

    [HttpDelete(Endpoints.Sportsmen.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _sportsmanService.DeleteSportsmanAsync(id);
        
        return NoContent();
    }
}
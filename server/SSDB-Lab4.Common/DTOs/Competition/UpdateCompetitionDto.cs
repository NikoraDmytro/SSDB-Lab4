using System.ComponentModel.DataAnnotations;
using SSDB_Lab4.Common.Attributes;

namespace SSDB_Lab4.Common.DTOs.Competition;

public class UpdateCompetitionDto
{
    [Required(ErrorMessage = "Competition name is required!")]
    [MaxLength(100, ErrorMessage = "Competition name must be less than 100 characters long!")]
    [MinLength(10, ErrorMessage = "Competition name must be more than 10 characters long!")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Competition start date is required!")]
    [ValidDate(
        onlyPast: false, 
        ErrorMessage = "Competition start date must be a valid date!"
    )]
    public string? StartDate { get; set; }

    [Range(1, 7, ErrorMessage = "Competition duration must be in range from 1 to 7 days!")]
    public int Duration { get; set; } = 1;
    
    [Required(ErrorMessage = "Competition city is required!")]
    [MaxLength(60, ErrorMessage = "City name must be less than 60 characters long!")]
    public string? City { get; set; }
}
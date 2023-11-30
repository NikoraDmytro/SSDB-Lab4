using System.ComponentModel.DataAnnotations;

namespace SSDB_Lab4.Common.DTOs.Competitors;

public class CreateCompetitorDto
{
    [Required(ErrorMessage = "Sportsman id is required!")]
    public int? SportsmanId { get; set; }
}
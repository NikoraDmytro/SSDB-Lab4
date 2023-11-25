using System.ComponentModel.DataAnnotations;

namespace SSDB_Lab4.Common.DTOs.Competitors;

public class UpdateCompetitorLapDto
{
    [Required(ErrorMessage = "Competitor lap num is required!")]
    public int? LapNum { get; set; }
}
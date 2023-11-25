using System.ComponentModel.DataAnnotations;

namespace SSDB_Lab4.Common.DTOs.Competitors;

public class UpdateCompetitorWeightDto
{
    [Required(ErrorMessage = "Competitor weighting result is required!")]
    [Range(0, 1000, ErrorMessage = "Weighting result must be in range from 0 to 1000 kilograms!")]
    public double? WeightingResult { get; set; }
}
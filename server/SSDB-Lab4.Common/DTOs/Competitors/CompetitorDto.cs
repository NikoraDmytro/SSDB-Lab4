namespace SSDB_Lab4.Common.DTOs.Competitors;

public class CompetitorDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Sex { get; set; }
    public double? WeightingResult { get; set; }
    public string? Division { get; set; }
    public int LapNum { get; set; }
}
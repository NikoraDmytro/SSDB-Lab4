namespace SSDB_Lab4.Common.DTOs.Competitors;

public class CompetitorDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public int Age { get; set; }
    public Sex Sex { get; set; }
    public double? WeightingResult { get; set; }
    public string? Division { get; set; }
    public int LapNum { get; set; }
}
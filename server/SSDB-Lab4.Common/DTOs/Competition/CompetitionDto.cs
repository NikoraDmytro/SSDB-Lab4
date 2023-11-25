namespace SSDB_Lab4.Common.DTOs.Competition;

public class CompetitionDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public int Duration { get; set; }
    public string? City { get; set; }
}
namespace SSDB_Lab4.Domain.entities;

public class CompetitionCopy: BaseEntity
{
    public int CompetitionId { get; set; }
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public int Duration { get; set; }
    public string? City { get; set; }
}
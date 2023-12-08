namespace SSDB_Lab4.Domain.entities;

public class FailedInsertCompetitorLog: BaseEntity
{
    public int SportsmanId { get; set; }
    public int CompetitionId { get; set; }
    public DateTime FailedAt { get; set; }
    
    public Sportsman? Sportsman { get; set; }
    public Competition? Competition { get; set; }
}
namespace SSDB_Lab4.Domain.entities;

public class Competitor: BaseEntity
{
    public int SportsmanId { get; set; }
    public int CompetitionId { get; set; }
    public float? WeightingResult { get; set; }
    public int? DivisionId { get; set; }
    public int LapNum { get; set; }
    
    public Division? Division { get; set; }
    public Sportsman? Sportsman { get; set; }
    public Competition? Competition { get; set; }
}
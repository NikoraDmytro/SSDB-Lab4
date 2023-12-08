namespace SSDB_Lab4.Domain.entities;

public class CompetitorLog: BaseEntity
{
    public int CompetitorId { get; set; }
    public DateTime ModifiedAt  { get; set; }
    
    public Competitor? Competitor { get; set; }
}
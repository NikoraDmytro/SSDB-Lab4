namespace SSDB_Lab4.Domain.entities;

public class Competition: BaseEntity
{
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public int Duration { get; set; }
    public string? City { get; set; }
    
    public ICollection<Competitor>? Competitors { get; set; }
}
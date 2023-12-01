using SSDB_Lab4.Common;

namespace SSDB_Lab4.Domain.entities;

public class Sportsman: BaseEntity
{
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Sex Sex { get; set; }
    
    public ICollection<Competitor> Competitors { get; set; }
        = new List<Competitor>();
}
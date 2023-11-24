using SSDB_Lab4.Common;

namespace SSDB_Lab4.Domain.entities;

public class Division: BaseEntity
{
    public string? Name { get; set; }
    public float? MinWeight { get; set; }
    public float? MaxWeight { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public Sex Sex { get; set; }
}
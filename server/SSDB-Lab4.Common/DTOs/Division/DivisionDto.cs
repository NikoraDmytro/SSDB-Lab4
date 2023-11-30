namespace SSDB_Lab4.Common.DTOs.Division;

public class DivisionDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double? MinWeight { get; set; }
    public double? MaxWeight { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string? Sex { get; set; }
}
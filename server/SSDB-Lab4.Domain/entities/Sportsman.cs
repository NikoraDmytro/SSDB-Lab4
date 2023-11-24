namespace SSDB_Lab4.Domain.entities;

public enum Sex
{
    M,
    F
}

public class Sportsman: BaseEntity
{
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Sex Sex { get; set; }
}
namespace SSDB_Lab4.Common.DTOs.Sportsman;

public class CreateSportsmanDto
{
    public Sex Sex { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public DateTime BirthDate { get; set; }
}
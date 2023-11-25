using SSDB_Lab4.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SSDB_Lab4.Common.DTOs.Sportsman;

public class UpdateSportsmanDto
{
    [Required(ErrorMessage = "Sportsman sex is required!")]
    [ValidEnumValue(typeof(Sex), ErrorMessage = "Sex can be either M (Male) or F (Female)")]
    public string? Sex { get; set; }
    
    [Required(ErrorMessage = "Sportsman first name is required!")]
    [MaxLength(ErrorMessage = "First name must be less than 60 characters long!")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Sportsman last name is required!")]
    [MaxLength(ErrorMessage = "Last name must be less than 60 characters long!")]
    public string? LastName { get; set; }
    
    [Required(ErrorMessage = "Sportsman birth date is required!")]
    [ValidDate(ErrorMessage = "Sportsman birth date must be a valid date in the past!")]
    public string? BirthDate { get; set; }
}
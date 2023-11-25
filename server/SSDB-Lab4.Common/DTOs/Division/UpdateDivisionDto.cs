using System.ComponentModel.DataAnnotations;
using SSDB_Lab4.Common.Attributes;

namespace SSDB_Lab4.Common.DTOs.Division;

public class UpdateDivisionDto
{
    [Required(ErrorMessage = "Division name is required!")]
    [MaxLength(ErrorMessage = "Division name must be less than 50 characters long!")]
    public String? Name { get; set; }
    
    [Range(0, 1000, ErrorMessage = "Min weight must be in range from 0 to 1000 kilograms!")]
    public double? MinWeight { get; set; }
    
    [Range(0, 1000, ErrorMessage = "Max weight must be in range from 0 to 1000 kilograms!")]
    public double? MaxWeight { get; set; }
    
    [Required(ErrorMessage = "Division min age is required!")]
    [Range(0, 100, ErrorMessage = "Min age must be in range from 0 to 100 years!")]
    public int? MinAge { get; set; }
    
    [Required(ErrorMessage = "Division max age is required!")]
    [Range(0, 100, ErrorMessage = "Max age must be in range from 0 to 100 years!")]
    public int? MaxAge { get; set; }
    
    [Required(ErrorMessage = "Division sex is required!")]
    [ValidEnumValue(typeof(Sex), ErrorMessage = "Sex can be either M (Male) or F (Female)")]
    public string? Sex { get; set; }
}
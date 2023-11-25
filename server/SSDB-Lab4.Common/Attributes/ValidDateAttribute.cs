using System.ComponentModel.DataAnnotations;

namespace SSDB_Lab4.Common.Attributes;

[AttributeUsage(AttributeTargets.Property 
                | AttributeTargets.Field)]
public class ValidDateAttribute: ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (!DateTime.TryParse(
                value as string, 
                out var dateValue))
        {
            return false;
        }

        return dateValue <= DateTime.Now;
    }
}
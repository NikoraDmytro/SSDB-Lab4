using System.ComponentModel.DataAnnotations;

namespace SSDB_Lab4.Common.Attributes;

[AttributeUsage(AttributeTargets.Property 
                | AttributeTargets.Field)]
public class ValidDateAttribute: ValidationAttribute
{
    private readonly bool _onlyPast;
    
    public ValidDateAttribute(bool onlyPast = true)
    {
        _onlyPast = onlyPast;
    }
    
    public override bool IsValid(object? value)
    {
        if (!DateTime.TryParse(
                value as string, 
                out var dateValue))
        {
            return false;
        }

        if (_onlyPast)
        {
            return dateValue <= DateTime.Now;
        }

        return true;
    }
}
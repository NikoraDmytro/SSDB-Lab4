using System.ComponentModel.DataAnnotations;

namespace SSDB_Lab4.Common.Attributes;

[AttributeUsage(
    AttributeTargets.Property 
    | AttributeTargets.Field)]
public class ValidEnumValueAttribute: ValidationAttribute
{
    private readonly Type _enumType;

    public ValidEnumValueAttribute(Type enumType)
    {
        _enumType = enumType;
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }

        return Enum.IsDefined(_enumType, value);
    }
}
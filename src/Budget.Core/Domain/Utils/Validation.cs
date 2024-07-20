namespace Budget.Core.Domain.Utils;

public static class Validation
{
    public static string ValidateString(
        this string value, 
        int minLength, 
        int maxLength)
    {
        if(string.IsNullOrEmpty(value)){
            throw new DomainException($"Value is empty.");
        }

        if(value.Length < minLength ||
            value.Length > maxLength)
        {
            throw new DomainException($"Invalid length: {value} - Min: {minLength}, Max: {maxLength}");
        }

        return value;
    }
}
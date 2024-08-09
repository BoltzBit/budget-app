namespace Budget.Core.Domain.Utils;

public static class Validation
{
    public static decimal ValidateDecimal(this decimal value)
    {
        if(value < 0) 
        {
            throw new DomainException($"Value is not permited to be less then zero.");
        }
        return value;
    }

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

    public static int ValidateInt(this int value)
    {
        if(value <= 0)
        {
            throw new DomainException($"Value is not permited to be less then zero.");
        }

        return value;
    }

    public static Guid ValidateGuid(this Guid guid)
    {
        if(guid == Guid.Empty)
        {
            throw new DomainException("Guid is invalid.");
        }

        return guid;
    }
}

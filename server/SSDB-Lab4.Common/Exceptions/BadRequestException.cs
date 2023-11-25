namespace SSDB_Lab4.Common.Exceptions;

public class BadRequestException: Exception
{
    public BadRequestException(string message): base(message)
    {
    }
}
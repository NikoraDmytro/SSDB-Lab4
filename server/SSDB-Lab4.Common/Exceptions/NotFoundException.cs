namespace SSDB_Lab4.Common.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(string message): base(message)
    {
    }
}
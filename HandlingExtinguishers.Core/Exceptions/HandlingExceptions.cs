namespace HandlingExtinguishers.Core.Exceptions;

using System.Net;

public class HandlingExceptions : Exception
{
    public HandlingExceptions() { }

    public HandlingExceptions(string message) : base(message)
    {

    }
}

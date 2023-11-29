using System.Net;

namespace HandlingExtinguisher.Core.Exceptions
{
    public class HandlingExceptions : Exception
    {
        public HttpStatusCode Code { get; }
        public object Error { get; }

        public HandlingExceptions(HttpStatusCode status, object error = null)
        {
            Code = status;
            Error = error;
        }
    }
}

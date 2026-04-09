using HandlingExtinguishers.Core.Localization;
using System.Net;

namespace HandlingExtinguisher.Core.Exceptions
{
    /// <summary>
    /// Exception specific to authentication operations that automatically handles localization
    /// and response structuring based on resource keys.
    /// </summary>
    public class AuthenticationException : Exception
    {
        public HttpStatusCode Code { get; }
        public object Error { get; }

        /// <summary>
        /// Creates an authentication exception with automatic localization.
        /// </summary>
        /// <param name="resourceMessageProvider">A function that takes a culture string and returns the localized message</param>
        /// <param name="localizationService">Service to get the current culture from HTTP context</param>
        /// <param name="statusCode">HTTP status code for the error response</param>
        public AuthenticationException(
            Func<string, string> resourceMessageProvider,
            ILocalizationService localizationService,
            HttpStatusCode statusCode = HttpStatusCode.Unauthorized)
        {
            var culture = localizationService.GetCurrentCulture();
            var message = resourceMessageProvider(culture);

            Code = statusCode;
            Error = new { Mensaje = message };
        }
    }
}

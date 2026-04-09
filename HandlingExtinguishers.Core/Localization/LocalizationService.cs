using Microsoft.AspNetCore.Http;

namespace HandlingExtinguishers.Core.Localization;

/// <summary>
/// Service to manage application localization based on HTTP request context
/// Reads the Accept-Language header to determine the user's preferred culture
/// </summary>
public interface ILocalizationService
{
    /// <summary>
    /// Gets the current culture code from the HTTP context
    /// Returns "en" if English is requested, "es" (Spanish) by default
    /// </summary>
    string GetCurrentCulture();
}

public class LocalizationService : ILocalizationService
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private const string DefaultCulture = "es";
    private const string EnglishCulture = "en";

    public LocalizationService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Detects the culture from the Accept-Language header
    /// Supports: "en", "es", "en-US", "es-ES", etc.
    /// </summary>
    public string GetCurrentCulture()
    {
        var httpContext = httpContextAccessor.HttpContext;
        
        if (httpContext?.Request.Headers.AcceptLanguage.Count > 0)
        {
            var acceptLanguage = httpContext.Request.Headers.AcceptLanguage.ToString();
            
            // Check if English is requested
            if (acceptLanguage.Contains("en", StringComparison.OrdinalIgnoreCase))
            {
                return EnglishCulture;
            }
            
            // Check if Spanish is explicitly requested
            if (acceptLanguage.Contains("es", StringComparison.OrdinalIgnoreCase))
            {
                return DefaultCulture;
            }
        }

        return DefaultCulture;
    }
}

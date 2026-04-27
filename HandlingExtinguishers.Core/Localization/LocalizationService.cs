namespace HandlingExtinguishers.Core.Localization;

using HandlingExtinguishers.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Globalization;

public class LocalizationService( IHttpContextAccessor httpContextAccessor ) : ILocalizationService
{
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

    public string GetCurrentCulture()
    {
        return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
    }
}

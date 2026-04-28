namespace HandlingExtinguishers.Core.Helpers;

public static class CommonConstants
{
    public const int PasswordMinimumLength = 7;

    public const bool PasswordRequireDigit = false;

    public const bool UserRequireUniqueEmail = true;

    public const bool LockoutAllowedForNewUsers = true;

    public const int LockoutDurationInMinutes = 2;

    public const int MaximumFailedAccessAttempts = 3;

    public const string JwtConfigurationSectionName = "JWTConfiguration";

    public const string JwtValidIssuerKeyName = "validIssuer";

    public const string JwtValidAudienceKeyName = "validAudience";

    public const string JwtSecurityKeyName = "securityKey";

    public const string RootPath = "/";

    public const string ScalarApiReferencePath = "/scalar/v1";

    public const string BearerSchemeName = "Bearer";

    public const string BearerSchemeType = "bearer";

    public const string JwtBearerFormat = "JWT";

    public const string JwtAuthenticationDescription = "Enter your JWT token";

    public const string CultureEn = "en";

    public const string CultureEs = "es";

    public const string CulturePath = "Localization";

    public const string ContentType = "application/json";

    public const string AuthenticationError = "Authentication error";

    public const string ErrorHandling = "Error handling";

    public const string ServerError = "Server error";

    public const string UnhandledException = "Unhandled exception";

    public const string ErrorMessage = "Error";

    public const string SettingsJWTConfiguracion = "JWTConfiguration";

    public const string ExpiryInMinutes = "expiryInMinutes";

    public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

    public const string DataBaseDefaultConnection = "DefaultConnection";

    public const string PropertyUpdatedAt = "UpdatedAt";

    public const string PropertyCreatedAt = "CreatedAt";

    public const string PropertyId = "Id";

    public const string IdColumnName = "id";

    public const string NameColumnName = "name";

    public const string TableNameCompany = "Company";

    public const string TableNameEmployee = "Employee";

    public const string EmailColumnName = "email";

    public const string AddressColumnName = "address";

    public const string PhoneColumnName = "phone";

    public const string NitColumnName = "nit";

    public const string CompanyIdColumnName = "companyId";

    public const string FirstNameColumnName = "firstName";

    public const string SecondNameColumnName = "secondName";

    public const string LastNameColumnName = "lastName";

    public const string SecondLastNameColumnName = "secondLastName";

    public const string ActiveColumnName = "active";

    public const string EmployeeIdPropertyName = "EmployeeId";

    public const string EmployeePropertyName = "Name";
}

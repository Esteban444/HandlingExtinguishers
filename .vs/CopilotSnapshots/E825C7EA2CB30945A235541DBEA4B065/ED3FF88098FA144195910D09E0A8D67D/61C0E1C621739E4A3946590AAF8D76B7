using HandlingExtinguishers.Configurations;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infraestructure.Middleware;
using HandlingExtinguishers.Models.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddContext(builder.Configuration);
builder.Services.AddOptions(builder.Configuration);
builder.Services.AdddependencyInjection();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(Automapper).Assembly);
});

var supportedCultures = new[] { CommonConstants.CultureEs, CommonConstants.CultureEn };

builder.Services.AddLocalization(options =>
    options.ResourcesPath = CommonConstants.CulturePath );

builder.Services.Configure<RequestLocalizationOptions>( options =>
{
    options.SetDefaultCulture( CommonConstants.CultureEs )
           .AddSupportedCultures(supportedCultures)
           .AddSupportedUICultures(supportedCultures);

    options.ApplyCurrentCultureToResponseHeaders = true;
});

builder.Services.AddIdentity<Users, IdentityRole>(options =>
{
    options.Password.RequiredLength = CommonConstants.PasswordMinimumLength;
    options.Password.RequireDigit = CommonConstants.PasswordRequireDigit;
    options.User.RequireUniqueEmail = CommonConstants.UserRequireUniqueEmail;
    options.Lockout.AllowedForNewUsers = CommonConstants.LockoutAllowedForNewUsers;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(CommonConstants.LockoutDurationInMinutes);
    options.Lockout.MaxFailedAccessAttempts = CommonConstants.MaximumFailedAccessAttempts;
}).AddEntityFrameworkStores<HandlingExtinguisherContext>().AddDefaultTokenProviders();


var jwtConfiguracion = builder.Configuration.GetSection(CommonConstants.JwtConfigurationSectionName);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfiguracion.GetSection(CommonConstants.JwtValidIssuerKeyName).Value,
        ValidAudience = jwtConfiguracion.GetSection(CommonConstants.JwtValidAudienceKeyName).Value,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtConfiguracion.GetSection(CommonConstants.JwtSecurityKeyName).Value!))
    };
});

builder.Services.AddScoped<JwtHandler>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILocalizationService, LocalizationService>();
builder.Services.AddPolicyCors();
builder.Services.AddControllers();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

var app = builder.Build();

app.UseRequestLocalization();

app.UseMiddleware<MiddlewareException>();

if ( app.Environment.IsDevelopment() )
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.MapGet(CommonConstants.RootPath, () => Results.Redirect(CommonConstants.ScalarApiReferencePath));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
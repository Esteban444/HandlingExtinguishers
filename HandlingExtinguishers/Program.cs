using FluentValidation.AspNetCore;
using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguisher.Infraestructure.Middleware;
using HandlingExtinguishers.Configurations;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.WebApi.Configurations;
using HandlingFireExtinguisher.Core.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios
builder.Services.AddContext(builder.Configuration);

builder.Services.AddOptions(builder.Configuration);

builder.Services.AdddependencyInjection();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<Users, IdentityRole>(options =>
{
    options.Password.RequiredLength = 7;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    options.Lockout.MaxFailedAccessAttempts = 3;
}).AddEntityFrameworkStores<HandlingExtinguisherContext>().AddDefaultTokenProviders();

var jwtConfiguracion = builder.Configuration.GetSection("JWTConfiguracion");
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
        ValidIssuer = jwtConfiguracion.GetSection("validIssuer").Value,
        ValidAudience = jwtConfiguracion.GetSection("validAudience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguracion.GetSection("securityKey").Value!))
    };
});

builder.Services.AddScoped<JwtHandler>();

builder.Services.AddPolicyCors();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(1));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


var app = builder.Build();

// Configure el pipeline de solicitud HTTP
app.UseMiddleware<MiddlewareException>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Handling Extinguishers v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();

using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Models.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace HandlingExtinguishers.WebApi.Configurations
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration Configuracion)
        {
            services.AddDbContext<HandlingExtinguisherContext>(options => options.UseSqlServer(Configuracion.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection AddIdentityToApp(this IServiceCollection services)
        {
            services.AddIdentity<Users, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<HandlingExtinguisherContext>().AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddPolicyCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            return services;
        }
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            var jwtConfiguracion = Configuration.GetSection("JWTConfiguracion");
            services.AddAuthentication(options =>
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

            return services;
        }

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Handling Extinguishers", Version = "v1" });
                 // Configuración de Swagger para JWT
                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Description = "Bearer",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer"
                 });
                 c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                     new OpenApiSecurityScheme
                     {
                        Reference = new OpenApiReference
                        {
                             Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                        }
                     },
                      new List<string>()
                   }
               });
             });
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers(option =>
            {


            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            return services;
        }
    }
}

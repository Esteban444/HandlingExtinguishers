using FluentValidation;
using HandlingEstinguishers.Core.Servicios;
using HandlingExtinguisher.Contracts.Interfaces.Services;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguisher.Dto.Employees;
using HandlingExtinguisher.Dto.Users;
using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Services;
using HandlingExtinguishers.Dto.Company;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infraestructura.Repositorios;
using HandlingExtinguishers.Infraestructure.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.WebApi.Configurations.Validators;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using HandlingFireExtinguisher.Core.Services;
using HandlingFireExtinguishers.Infraestructure.Repositories;
using ManagementFireEstinguisher.Core.Servicios;
using ManagementFireEstinguisher.Dto.Credit;
using ManagementFireEstinguisher.Dto.Expenses;
using ManagementFireEstinguisher.Dto.Extinguishers;
using ManagementFireEstinguisher.Dto.Inventories;
using ManagementFireEstinguisher.Dto.Prices;
using ManagementFireEstinguisher.Dto.Products;
using ManagementFireEstinguisher.Dto.Services;
using ManagementFireEstinguisher.Dto.Users;
using ManejoExtintores.Core.Servicios;
using MHandlingExtinguishers.Infraestructura.Repositorios;
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
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryCompany, CompanyRepository>();

            services.AddScoped<IRepositoryClient, RepositoryClient>();
            services.AddScoped<IRepositoryCredit, RepositoryCredit>();
            services.AddScoped<IRepositoryDetailService, RepositoryDetailService>();
            services.AddScoped<IRepositoryDetailExtinguisherClient, RepositoryDetailExtinguisherClient>();
            services.AddScoped<IRepositoryEmployee, RepositorioEmpleado>();
            services.AddScoped<IRepositoryExpense, RepositoryExpense>();
            services.AddScoped<IRepositoryInventory, RepositoryInventory>();
            services.AddScoped<IRepositoryPrice, RepositoryPrice>();
            services.AddScoped<IRepositoryProduct, RepositoryProduct>();
            services.AddScoped(typeof(IBaseRepository<WeightExtinguisher>), typeof(BaseRepository<WeightExtinguisher>));
            services.AddScoped(typeof(IBaseRepository<TypeExtinguisher>), typeof(BaseRepository<TypeExtinguisher>));
            services.AddScoped<IRepositoryService, RepositoryService>();

            services.AddScoped<IValidator<BaseClient>, ValidacionClientes>();
            services.AddScoped<IValidator<CreditoServicioBase>, ValidacionCreditos>();
            services.AddScoped<IValidator<BaseDetailExtinguisherClient>, ValidacionDetalleExtintorClientes>();
            services.AddScoped<IValidator<CompanyBase>, ValidacionesEmpresas>();
            services.AddScoped<IValidator<EmployeeBase>, ValidacionEmpleados>();
            services.AddScoped<IValidator<GastosBase>, ValidacionesGastos>();
            services.AddScoped<IValidator<InventarioBase>, ValidacionInventario>();
            services.AddScoped<IValidator<PesoExtintorBase>, ValidacionPesoExtintor>();
            services.AddScoped<IValidator<PrecioBase>, ValidacionesPrecios>();
            services.AddScoped<IValidator<ProductoBase>, ValidacionesProducto>();
            services.AddScoped<IValidator<TipoExtintorBase>, ValidacionTipoExtintor>();
            services.AddScoped<IValidator<ServicioBase>, ValidacionServicios>();
            services.AddScoped<IValidator<LoginRequestDto>, ValidacionAutenticacionUsuario>();
            services.AddScoped<IValidator<VerificacionDosPasosDTO>, ValidacionVerificacionDosPasos>();

            services.AddScoped<IServicieClient, ServicioCliente>();
            services.AddScoped<IServicieCredit, ServiceCredit>();
            services.AddScoped<IDetailService, ServicioDetalleServicios>();
            services.AddScoped<IServicioDetalleExtClientes, ServicioDetalleExtClientes>();
            services.AddScoped<IServicioGasto, ServicioGasto>();
            services.AddScoped<IServiceCompany, ServiceCompany>();
            services.AddScoped<IServiceEmployee, ServiceEmployee>();
            services.AddScoped<IServicioInventario, ServicioInventario>();
            services.AddScoped<IServicioPrecios, ServicioPrecios>();
            services.AddScoped<IServicioProducto, ServicioProducto>();
            services.AddScoped<IServicioPesoExtintor, ServicioPesoExtintor>();
            services.AddScoped<IServicioTipoExtintor, ServicioTipoExtintor>();
            services.AddScoped<IServiceOfService, ServiceOfService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}

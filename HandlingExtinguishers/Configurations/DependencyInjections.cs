using FluentValidation;
using HandlingEstinguishers.Core.Servicios;
using HandlingExtinguisher.Contracts.Interfaces.Services;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguisher.Dto.Employees;
using HandlingExtinguisher.Dto.Users;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Services;
using HandlingExtinguishers.Infraestructura.Repositorios;
using HandlingExtinguishers.Infraestructure.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;
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
using ManejoExtintores.Core.Servicios;
using MHandlingExtinguishers.Infraestructura.Repositorios;

namespace HandlingExtinguishers.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection AdddependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryCompany, CompanyRepository>();

            services.AddScoped<IRepositoryClient, RepositoryClient>();
            services.AddScoped<IRepositoryCredit, RepositoryCredit>();
            services.AddScoped<IRepositoryDetailService, RepositoryDetailService>();
            services.AddScoped<IRepositoryDetailExtinguisherClient, RepositoryDetailExtinguisherClient>();
            services.AddScoped<IRepositoryEmployee, RepositoryEmployee>();
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

            // services.AddScoped<IValidator<CompanyBase>, ValidatorCompany>();
            services.AddValidatorsFromAssemblyContaining<ValidatorCompany>();

            services.AddScoped<IValidator<EmployeeBase>, ValidacionEmpleados>();
            services.AddScoped<IValidator<GastosBase>, ValidacionesGastos>();
            services.AddScoped<IValidator<InventarioBase>, ValidacionInventario>();
            services.AddScoped<IValidator<PesoExtintorBase>, ValidacionPesoExtintor>();
            services.AddScoped<IValidator<PrecioBase>, ValidacionesPrecios>();
            services.AddScoped<IValidator<ProductoBase>, ValidacionesProducto>();
            services.AddScoped<IValidator<TipoExtintorBase>, ValidacionTipoExtintor>();
            services.AddScoped<IValidator<ServicioBase>, ValidacionServicios>();
            services.AddScoped<IValidator<LoginRequestDto>, ValidacionAutenticacionUsuario>();

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

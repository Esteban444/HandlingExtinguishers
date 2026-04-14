namespace HandlingExtinguishers.Configurations;

#region Usings
using FluentValidation;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Services;
using HandlingExtinguishers.Infraestructura.Repositorios;
using HandlingExtinguishers.Infraestructure.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Configurations.Validators;
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
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Authentication;
using HandlingExtinguishers.Models.Models;
#endregion

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
        services.AddScoped<IBaseRepository<WeightExtinguisher>, BaseRepository<WeightExtinguisher>>();
        services.AddScoped<IBaseRepository<TypeExtinguisher>, BaseRepository<TypeExtinguisher>>();
        services.AddScoped<IRepositoryService, RepositoryService>();

        services.AddScoped<IValidator<BaseClient>, ValidatorClient>();
        services.AddScoped<IValidator<CreditoServicioBase>, ValidatorCredit>();
        services.AddScoped<IValidator<BaseDetailExtinguisherClient>, ValidatorDetailExtinguisherClient>();

     
        services.AddValidatorsFromAssemblyContaining<ValidatorCompany>();
        services.AddValidatorsFromAssemblyContaining<ValidatorEmployee>();

        services.AddScoped<IValidator<GastosBase>, ValidatorExpense>();
        services.AddScoped<IValidator<InventarioBase>, ValidatorInventory>();
        services.AddScoped<IValidator<WeightExtinguisherBase>, ValidatorWieghtExtinguisher>();
        services.AddScoped<IValidator<PrecioBase>, ValidatorPrice>();
        services.AddScoped<IValidator<ProductoBase>, ValidatorProduct>();
        services.AddScoped<IValidator<TipoExtintorBase>, ValidatorTypeExtinguisher>();
        services.AddScoped<IValidator<ServicioBase>, ValidatorService>();
        services.AddScoped<IValidator<LoginRequestDto>, ValidatorAuthenticationUser>();

        services.AddScoped<IClientService, ServicioCliente>();
        services.AddScoped<ICreditService, ServiceCredit>();
        services.AddScoped<IDetailService, DetailServices>();
        services.AddScoped<IServiceDetailExtinguisherClients, ServicioDetalleExtClientes>();
        services.AddScoped<IExpenseService, ServicioGasto>();
        services.AddScoped<ICompanyService, ServiceCompany>();
        services.AddScoped<IEmployeeService, ServiceEmployee>();
        services.AddScoped<IInventoryService, ServicioInventario>();
        services.AddScoped<IPriceService, ServicioPrecios>();
        services.AddScoped<IProductService, ServicioProducto>();
        services.AddScoped<IWeightExtinguisherService, ServiceWeightExtinguisher>();
        services.AddScoped<ITypeExtinguisherService, ServicioTipoExtintor>();
        services.AddScoped<IServiceOfService, ServiceOfService>();
        services.AddScoped<IAuthentificationService, AuthentificationService>();

        return services;
    }
}

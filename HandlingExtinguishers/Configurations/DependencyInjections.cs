namespace HandlingExtinguishers.Configurations;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Services;
using HandlingExtinguishers.Infraestructura.Repositorios;
using HandlingExtinguishers.Infraestructure.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Configurations.Validators;
using HandlingFireExtinguishers.Infraestructure.Repositories;
using ManagementFireEstinguisher.Core.Servicios;
using ManagementFireEstinguisher.Dto.Inventories;
using ManagementFireEstinguisher.Dto.Products;
using ManejoExtintores.Core.Servicios;
using MHandlingExtinguishers.Infraestructura.Repositorios;
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Authentication;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Credit;
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Services;
using HandlingExtinguishers.Models.Prices;
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

        services.AddScoped<IValidator<ClientRequest>, ValidatorClient>();
        services.AddScoped<IValidator<CreditServiceRequest>, ValidatorCredit>();
        services.AddScoped<IValidator<DetailExtinguisherClientRequest>, ValidatorDetailExtinguisherClient>();

     
        services.AddValidatorsFromAssemblyContaining<ValidatorCompany>();
        services.AddValidatorsFromAssemblyContaining<ValidatorEmployee>();

        services.AddScoped<IValidator<ExpenseRequest>, ValidatorExpense>();
        services.AddScoped<IValidator<InventarioBase>, ValidatorInventory>();
        services.AddScoped<IValidator<WeightExtinguisherBase>, ValidatorWieghtExtinguisher>();
        services.AddScoped<IValidator<PrecioBase>, ValidatorPrice>();
        services.AddScoped<IValidator<ProductoBase>, ValidatorProduct>();
        services.AddScoped<IValidator<TypeExtinguisherRequest>, ValidatorTypeExtinguisher>();
        services.AddScoped<IValidator<ServiceRequest>, ValidatorService>();
        services.AddScoped<IValidator<LoginRequest>, ValidatorAuthenticationUser>();

        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICreditService, Core.Services.CreditService>();
        services.AddScoped<IDetailService, DetailServices>();
        services.AddScoped<IServiceDetailExtinguisherClients, DetailExtinguisherClientService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IInventoryService, InventaryService>();
        services.AddScoped<IPriceService, PreceService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IWeightExtinguisherService, WeightExtinguisherService>();
        services.AddScoped<ITypeExtinguisherService, TypeExtinguisherService>();
        services.AddScoped<IServiceOfService, ServiceOfService>();
        services.AddScoped<IAuthentificationService, AuthentificationService>();

        return services;
    }
}

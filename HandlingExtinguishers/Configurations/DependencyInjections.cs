namespace HandlingExtinguishers.Configurations;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Configurations.Validators;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core;
using HandlingExtinguishers.Core.CommandServices;
using HandlingExtinguishers.Core.QueryServices;
using HandlingExtinguishers.Core.Services;
using HandlingExtinguishers.Infraestructure.Repositories;
using HandlingExtinguishers.Models.Authentication;
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Credit;
using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Inventories;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Prices;
using HandlingExtinguishers.Models.Products;
using HandlingExtinguishers.Models.Services;
#endregion

public static class DependencyInjections
{
    public static IServiceCollection AdddependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICompanyRepository, CompanyRepository>();

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ICreditServiceRepository, CreditRepository>();
        services.AddScoped<IDetailServiceRepository, DetailServiceReposytory>();
        services.AddScoped<IDetailExtinguisherClientRepository, DetailExtinguisherClientRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IPriceRepository, PriceRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBaseRepository<WeightExtinguisher>, BaseRepository<WeightExtinguisher>>();
        services.AddScoped<IBaseRepository<TypeExtinguisher>, BaseRepository<TypeExtinguisher>>();
        services.AddScoped<IServiceRepository, ServiceRepository>();

        services.AddScoped<IValidator<ClientRequest>, ValidatorClient>();
        services.AddScoped<IValidator<CreditServiceRequest>, ValidatorCredit>();
        services.AddScoped<IValidator<DetailExtinguisherClientRequest>, ValidatorDetailExtinguisherClient>();

     
        services.AddValidatorsFromAssemblyContaining<ValidatorCompany>();
        services.AddValidatorsFromAssemblyContaining<ValidatorEmployee>();

        services.AddScoped<IValidator<ExpenseRequest>, ValidatorExpense>();
        services.AddScoped<IValidator<InventarioRequest>, ValidatorInventory>();
        services.AddScoped<IValidator<WightExtinguisherRequest>, ValidatorWieghtExtinguisher>();
        services.AddScoped<IValidator<PriceRequest>, ValidatorPrice>();
        services.AddScoped<IValidator<ProductRequest>, ValidatorProduct>();
        services.AddScoped<IValidator<TypeExtinguisherRequest>, ValidatorTypeExtinguisher>();
        services.AddScoped<IValidator<ServiceRequest>, ValidatorService>();
        services.AddScoped<IValidator<LoginRequest>, ValidatorAuthenticationUser>();

        // Query & Command services
        services.AddScoped<ICompanyQueryService, CompanyQueryService>();
        services.AddScoped<ICompanyCommandService, CompanyCommandService>();

        

        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICreditService, Core.Services.CreditService>();
        services.AddScoped<IDetailService, DetailServices>();
        services.AddScoped<IServiceDetailExtinguisherClients, DetailExtinguisherClientService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IInventoryService, InventaryService>();
        services.AddScoped<IPriceService, PreceService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IWeightExtinguisherService, WeightExtinguisherService>();
        services.AddScoped<ITypeExtinguisherService, TypeExtinguisherService>();
        services.AddScoped<IServiceOfService, ServiceOfService>();
        services.AddScoped<IAuthentificationCommandService, AuthentificationService>();

        return services;
    }
}

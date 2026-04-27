namespace HandlingExtinguishers.Configurations;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Company;
using HandlingExtinguishers.Models.Credit;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Inventories;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Prices;
using HandlingExtinguishers.Models.Products;
using HandlingExtinguishers.Models.Services;
#endregion

public class Automapper : Profile
{
    public Automapper()
    {
        CreateMap<Users, RegisterUserRequest>().ReverseMap();

        CreateMap<Client, ClientRequest>().ReverseMap();

        CreateMap<CreditService, CreditServiceRequest>()
            .ForMember(x => x.Service, y => y.MapFrom(z => z.Service));

        CreateMap<DetailService, DetailServiceResponse>().ReverseMap() ;
            //.ForMember(x => x.Inv, y => y.MapFrom(z => z.Inventories))
            //.ForMember(x => x.W, y => y.MapFrom(z => z.WeightExtinguisher))
            //.ForMember(x => x.Prices, y => y.MapFrom(z => z.Price))
            //.ForMember(x => x.TypeExtinguisher, y => y.MapFrom(z => z.TypeExtinguisher));
        CreateMap<DetailService, DetailServiceRequest>().ReverseMap();

        CreateMap<DetailExtinguisherClient, DetailExtinguisherClientRequest>()
            .ForMember(x => x.Client, y => y.MapFrom(z => z.Client));

        CreateMap<Company, CompanyResponse>().ReverseMap();
        CreateMap<Company, CompanyRequest>().ReverseMap();

        CreateMap<Employee, EmployeeResponse>()
            .ForMember(x => x.Company, y => y.MapFrom(z => z.Company));
        CreateMap<Employee, EmployeeRequest>().ReverseMap();

        CreateMap<Inventory, InventarioRequest>()
            .ForMember(x => x.Product, y => y.MapFrom(z => z.Product))
            .ForMember(x => x.WeightExtinguisher, y => y.MapFrom(z => z.WeightExtinguisher))
            .ForMember(x => x.TypeExtinguisher, y => y.MapFrom(z => z.TypeExtinguisher));
        CreateMap<Inventory, InventarioRequest>().ReverseMap();


        CreateMap<Expense, ExpenseRequest>().ReverseMap();

        CreateMap<Price, PriceRequest>().ReverseMap();
        CreateMap<Price, PriceRequest>()
            .ForMember(x => x.Product, y => y.MapFrom(z => z.Product));
        CreateMap<PriceRequest, PriceResponse>()
            .ForMember(x => x.Product, y => y.MapFrom(z => z.Product));

        CreateMap<Product, ProductRequest>().ReverseMap();
        CreateMap<Product, ProductResponse>()
            .ForMember(x => x.TypeExtinguisher, y => y.MapFrom(z => z.TypeExtinguisher))
            .ForMember(x => x.WightExtinguisher, y => y.MapFrom(z => z.WeightExtinguisher));

        CreateMap<WeightExtinguisher, WightExtinguisherRequest>().ReverseMap();
        CreateMap<WeightExtinguisher, WightExtinguisherRequest>().ReverseMap();

        CreateMap<TypeExtinguisher, TypeExtinguisherRequest>().ReverseMap();

        CreateMap<Service, ServiceRequest>().ReverseMap();
        CreateMap<Service, EditStatus>().ReverseMap();
        CreateMap<Service, Service>()
            .ForMember(x => x.Client, y => y.MapFrom(z => z.Client))
            .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee));
    }
}

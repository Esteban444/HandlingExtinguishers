namespace HandlingExtinguishers.Configurations;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Company;
using HandlingExtinguishers.Models.Models;
using ManagementFireEstinguisher.Dto;
using ManagementFireEstinguisher.Dto.Inventories;
using ManagementFireEstinguisher.Dto.Products;
using ManagementFireEstinguisher.Dto.Users;
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Credit;
using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Services;
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Inventories;
using HandlingExtinguishers.Models.Products;
using HandlingExtinguishers.Models.Prices;
#endregion

public class Automapper : Profile
{
    public Automapper()
    {
        CreateMap<Users, RegisterUserDto>().ReverseMap();

        CreateMap<Client, ClientRequest>().ReverseMap();

        CreateMap<CreditService, CreditServiceRequest>()
            .ForMember(x => x.Service, y => y.MapFrom(z => z.Service));

        CreateMap<DetailService, DetalleServicioDTO>()
            .ForMember(x => x.Inventarios, y => y.MapFrom(z => z.Inventories))
            .ForMember(x => x.PesoExtintor, y => y.MapFrom(z => z.WeightExtinguisher))
            .ForMember(x => x.Precios, y => y.MapFrom(z => z.Price))
            .ForMember(x => x.TipoExtintor, y => y.MapFrom(z => z.TypeExtinguisher));
        CreateMap<DetailService, DetalleServicioBase>().ReverseMap();

        CreateMap<DetailExtinguisherClient, DetailExtinguisherClientRequest>()
            .ForMember(x => x.Client, y => y.MapFrom(z => z.Client));

        CreateMap<Company, CompanyResponse>().ReverseMap();
        CreateMap<Company, CompanyRequest>().ReverseMap();
        CreateMap<Company, PatchCompanyRequest>().ReverseMap();

        CreateMap<Employee, EmployeeResponse>()
            .ForMember(x => x.Company, y => y.MapFrom(z => z.Company));
        CreateMap<Employee, EmployeeRequest>().ReverseMap();
        CreateMap<Employee, EmployeeBaseResponse>().ReverseMap();
        CreateMap<EmployeeRequest, EmployeeBaseResponse>().ReverseMap();

        CreateMap<Inventory, InventarioDTO>()
            .ForMember(x => x.Producto, y => y.MapFrom(z => z.Product))
            .ForMember(x => x.PesoExtintor, y => y.MapFrom(z => z.WeightExtinguisher))
            .ForMember(x => x.TipoExtintor, y => y.MapFrom(z => z.TypeExtinguisher));
        CreateMap<Inventory, InventarioBase>().ReverseMap();


        CreateMap<Expense, ExpenseRequest>().ReverseMap();

        CreateMap<Price, PrecioBase>().ReverseMap();
        CreateMap<Price, PrecioDTO>()
            .ForMember(x => x.Producto, y => y.MapFrom(z => z.Product));

        CreateMap<Product, ProductoBase>().ReverseMap();
        CreateMap<Product, ProductoDTO>()
            .ForMember(x => x.TipoExtintor, y => y.MapFrom(z => z.TypeExtinguisher))
            .ForMember(x => x.PesoExtintor, y => y.MapFrom(z => z.WeightExtinguisher));

        CreateMap<WeightExtinguisher, WeightExtinguisherBase>().ReverseMap();
        CreateMap<WeightExtinguisher, WightExtuinguiserDto>().ReverseMap();

        CreateMap<TypeExtinguisher, TypeExtinguisherRequest>().ReverseMap();

        CreateMap<Service, ServiceRequest>().ReverseMap();
        CreateMap<Service, EditStatus>().ReverseMap();
        CreateMap<Service, Service>()
            .ForMember(x => x.Client, y => y.MapFrom(z => z.Client))
            .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee));
    }
}
